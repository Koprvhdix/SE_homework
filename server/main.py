import tornado.httpserver
import tornado.ioloop
import tornado.options
import tornado.web
import mysql.connector
import datetime
import json

from uuid import uuid4

from tornado.options import define, options
define("port", default=8888, help="run on the given port", type=int)

def add_str(string):
    string = '\'' + string + '\''
    return string

class InOutLoginHandler(tornado.web.RequestHandler):
    def post(self):
        user_id = self.get_argument("user_id")
        password = self.get_argument("password")
        conn = mysql.connector.connect(user='root', password='1234', database='parking_place_manage_system', use_unicode=True)
        cursor = conn.cursor()
        cursor.execute('select user_name from common_user;')
        user_list = cursor.fetchall()
        user_name = []
        for item in user_list:
            user_name.append(item[0])
        if user_id in user_name:
            cursor.execute('select password from common_user where user_name = %s;' % add_str(user_id))
            password_get = cursor.fetchall()
            password_right = password_get[0][0].encode("UTF-8")
            if password == password_right:
                session_current = uuid4()
                session_current = str(session_current)
                self.write(session_current)
                cursor.execute('select user_name from session;')
                user_name_in_session = cursor.fetchall()
                user_session = []
                for item in user_name_in_session:
                    user_session.append(item[0])
                if user_id in user_session:
                    cursor.execute('delete from session where user_name = %s;' % add_str(user_id))
                    conn.commit()
                cursor.execute('insert into session values (%s, %s);' % (add_str(user_id), add_str(session_current)))
                conn.commit()
            else:
                self.write("Password Error")
        else:
            self.write("User isn't existed")
        cursor.close()
        conn.close()

class ParkingCountHandler(tornado.web.RequestHandler):
    def get(self):
        conn = mysql.connector.connect(user='root', password='1234', database='parking_place_manage_system', use_unicode=True)
        cursor = conn.cursor()
        cursor.execute('select * from left_parking_place;')
        left_number = cursor.fetchall()
        left_number = str(left_number[0][0])
        left_number = left_number.replace(')', '')
        left_number = left_number.replace('(', '')
        left_number = left_number.replace(',', '')
        self.write(str(left_number))

class InOutCommitCard(tornado.web.RequestHandler):
    def post(self):
        user_id = self.get_argument("user_id")
        session_current = self.get_argument("session")
        card_num = self.get_argument("card_num")
        car_num = self.get_argument("car_num")
        conn = mysql.connector.connect(user='root', password='1234', database='parking_place_manage_system', use_unicode=True)
        cursor = conn.cursor()
        cursor.execute('select user_name from session;')
        user_list = cursor.fetchall()
        user_name = []
        for item in user_list:
            user_name.append(item[0])
        if user_id not in user_name:
            self.write("Error")
            return
        cursor.execute('select session from session where user_name = %s;' % add_str(user_id))
        session = cursor.fetchall()
        session_list = []
        for item in session:
            session_list.append(item[0])
        if session_current == session_list[0]:
            session_current = uuid4()
            session_current = str(session_current)
            if car_num == "":
                return_data = {}
                record_num = -1
                for i in range(len(record)):
                    if record[i]['card_num'] == card_num:
                        record_num = i
                        break
                if record_num == -1:
                    self.write("Error")
                    return
                else:
                    current_time = datetime.datetime.now()
                    stay_time_day = (current_time - record[record_num]['enter_time']).days
                    stay_time_seconds = (current_time - record[record_num]['enter_time']).seconds
                    if record[record_num]['card_quality'] == 'fixed':
                        cursor.execute('select left_hour, card_money, combo_ID, uncalculate from fixed_card where card_num = %s;' % (add_str(card_num)))
                        card_information = []
                        for item in cursor.fetchall():
                            card_information.append(item[0])
                            card_information.append(item[1])
                            card_information.append(item[2])
                            card_information.append(item[3])
                        left_hour = int(card_information[0])
                        card_money = int(card_information[1])
                        combo_ID = card_information[2]
                        uncalculate = int(card_information[3])
                        using_hour = stay_time_day * 24 + (stay_time_seconds + uncalculate) / 3600
                        uncalculate = (stay_time_seconds + uncalculate) % 3600
                        if left_hour - using_hour < 0:
                            cursor.execute('select money_per_hour from card_combo where combo_ID = %s;' % (add_str(combo_ID)))
                            money_per_hour = []
                            for item in cursor.fetchall():
                                money_per_hour.append(item[0])
                            money_per_hour = money_per_hour[0]
                            money = money_per_hour * (using_hour - left_hour)
                            card_money -= money
                            cursor.execute('update fixed_card set left_hour = 0, uncalculate = 0, card_money = %s where card_num = %s;' % (card_money, add_str(card_num)))
                            conn.commit()
                            return_data['money'] = money
                        else:
                            left_hour -= using_hour
                            cursor.execute('update fixed_card set left_hour = %s, uncalculate = %s where card_num = %s;' % (left_hour, uncalculate, add_str(card_num)))
                            conn.commit()
                            return_data['money'] = 0
                    else:
                        cursor.execute('select * from temporary_money;')
                        temporary_money = []
                        money = 0.0
                        using_hour = stay_time_day * 24 + stay_time_seconds / 3600
                        uncalculate = stay_time_seconds % 3600
                        add_time_str = str(current_time.year) + "-" + str(current_time.month) + "-" + str(current_time.day) + " "
                        for item in cursor.fetchall():
                            date = []
                            time_str = add_time_str + str(item[1])
                            time = datetime.datetime.strptime(time_str, "%Y-%m-%d %H:%M:%S")
                            date.append(time)
                            date.append(item[2])
                            temporary_money.append(date)
                        if stay_time_day >= 1:
                            start_hour = 0
                            for item in temporary_money:
                                item_hour = item[0].hour
                                if item_hour == 0:
                                    item_hour = 24
                                hours = int(item_hour - start_hour)
                                money += hours * item[1]
                                start_hour = item[0].hour
                            money *= stay_time_day
                        temporary_money.extend(temporary_money)
                        next_leave = False
                        for i in range(len(temporary_money) - 1):
                            start_calculate = i
                            item_hour = temporary_money[i + 1][0].hour
                            if item_hour == 0:
                                item_hour = 24
                            if record[record_num]['enter_time'].hour >= temporary_money[i][0].hour and record[record_num]['enter_time'].hour < item_hour:
                                if current_time.hour >= temporary_money[i][0].hour and current_time.hour < item_hour:
                                    hours = ((current_time - record[record_num]['enter_time']).seconds / 3600)
                                    money += (hours * temporary_money[i + 1][1])
                                    break
                                else:
                                    next_leave = True
                                    start_calculate = i - 1
                                    hours = int((temporary_money[i + 1][0] - record[record_num]['enter_time']).seconds / 3600)
                                    money += (hours * temporary_money[i + 1][1])
                            if next_leave and current_time.hour >= temporary_money[i][0].hour and current_time.hour < item_hour:
                                hours = int((current_time - temporary_money[i][0]).seconds / 3600)
                                money += (hours * temporary_money[i + 1][1])
                                break
                            if next_leave and start_calculate == i:
                                hours = int((temporary_money[i + 1][0] - temporary_money[i][0]).seconds / 3600)
                                money += (hours * temporary_money[i + 1][1])
                        return_data['money'] = money
                        cursor.execute('update left_parking_place set left_number = left_number + 1, in_number = in_number - 1;')
                        conn.commit()
                    return_data['card_quality'] = record[record_num]['card_quality']
                    return_data['leave_time'] = current_time.strftime("%Y-%m-%d %H:%M:%S")
                    return_data['enter_time'] = record[record_num]['enter_time'].strftime("%Y-%m-%d %H:%M:%S")
                    return_data['car_num'] = record[record_num]['car_num']
                    return_data['session'] = session_current
                    return_data['parking_position'] = record[record_num]['parking_position']
                    using_time = str(using_hour) + ':' + str(uncalculate / 60) + ':' + str(uncalculate % 60)
                    cursor.execute('update session set session = %s where user_name = %s;' % (add_str(session_current), add_str(user_id)))
                    conn.commit()
                    cursor.execute('insert into card_record values (%s, %s, %s, %s, %s, %s);' % (add_str(card_num), add_str(return_data['car_num']), add_str(return_data['enter_time']), add_str(return_data['leave_time']), add_str(using_time), return_data['money']))
                    conn.commit()
                    return_data = json.dumps(return_data)
                    self.write(str(return_data))
                    record.remove(record[record_num])
            else:
                for item in record:
                    if item['card_num'] == card_num:
                        self.write("Error")
                        return
                data = {}
                return_data = {}
                cursor.execute('select card_num from fixed_card;')
                card_num2 = cursor.fetchall()
                card_num1 = []
                for item in card_num2:
                    card_num1.append(item[0])
                if card_num in card_num1:
                    data['card_quality'] = 'fixed'
                    cursor.execute('select parking_position_ID from fixed_card where card_num = %s;' % add_str(card_num))
                    parking_posititon = cursor.fetchall()
                    parking_posititon_ID = []
                    for item in parking_posititon:
                        parking_posititon_ID.append(item[0])
                    data['parking_position'] = parking_posititon_ID[0]
                else:
                    cursor.execute('select card_num from temporary_card;')
                    card_num2 = cursor.fetchall()
                    card_num1 = []
                    for item in card_num2:
                        card_num1.append(item[0])
                    if card_num in card_num1:
                        data['card_quality'] = 'temporary'
                        cursor.execute('select parking_position_ID from temporary_card where card_num = %s;' % add_str(card_num))
                        parking_posititon = cursor.fetchall()
                        parking_posititon_ID = []
                        for item in parking_posititon:
                            parking_posititon_ID.append(item[0])
                        data['parking_position'] = parking_posititon_ID[0]
                        cursor.execute('update left_parking_place set left_number = left_number - 1, in_number = in_number + 1;')
                        conn.commit()
                    else:
                        self.write("Error")
                        return
                data['card_num'] = card_num
                enter_time = datetime.datetime.now()
                data['enter_time'] = enter_time
                return_data['session'] = session_current
                return_data['enter_time'] = enter_time.strftime("%Y-%m-%d %H:%M:%S")
                return_data['card_quality'] = data['card_quality']
                data['car_num'] = car_num
                return_data['parking_position'] = data['parking_position']
                cursor.execute('update session set session = %s where user_name = %s;' % (add_str(session_current), add_str(user_id)))
                conn.commit()
                record.append(data)
                return_data = json.dumps(return_data)
                self.write(str(return_data))
        else:
            self.write("Error")
        cursor.close()
        conn.close()

class OutInLogin(tornado.web.RequestHandler):
    def post(self):
        user_id = self.get_argument("user_id")
        session_current = self.get_argument("session")
        conn = mysql.connector.connect(user='root', password='1234', database='parking_place_manage_system', use_unicode=True)
        cursor = conn.cursor()
        cursor.execute('select user_name from session;')
        user_name = []
        for item in cursor.fetchall():
            user_name.append(item[0])
        if user_id in user_name:
            cursor.execute('select session from session where user_name = %s;' % add_str(user_id))
            session = []
            for item in cursor.fetchall():
                session.append(item[0])
            if session_current == session[0]:
                cursor.execute('delete from session where user_name = %s;' % add_str(user_id))
                conn.commit()
            else:
                self.write('Error')
        else:
            self.write('Error')
        cursor.close()
        conn.close()

class ManageLogin(tornado.web.RequestHandler):
    def post(self):
        current_time = datetime.datetime.now()
        manage_user_id = self.get_argument("manage_user_id")
        manage_user_password = self.get_argument("password")
        conn = mysql.connector.connect(user='root', password='1234', database='parking_place_manage_system', use_unicode=True)
        cursor = conn.cursor()
        cursor.execute('select * from next_month')
        next_time = ""
        for item in cursor.fetchall():
            next_time = item[0]
        next_time = datetime.datetime.strptime(next_time, "%Y-%m-%d")
        if next_time.year == current_time.year and next_time.month == current_time.month and next_time.day == current_time.day:
            if current_time.month in [1, 3, 5, 7, 8, 10, 12]:
                next_time = next_time + datetime.timedelta(days=31)
            elif current_time.month in [4, 6, 9, 11]:
                next_time = next_time + datetime.timedelta(days=30)
            else:
                next_time = next_time + datetime.timedelta(days=28)
            cursor.execute('update fixed_card set card_money = card_money-(select combo_money from card_combo where combo_ID = fixed_card.combo_ID);')
            conn.commit()
            cursor.execute('update next_month set next_month_1st = %s' % (add_str(str(next_time.year) + '-' + str(next_time.month) + '-' + str(next_time.day))))
            conn.commit()
        cursor.execute('select user_name from manage_user;')
        manage_user = []
        for item in cursor.fetchall():
            manage_user.append(item[0])
        if manage_user_id in manage_user:
            cursor.execute('select password from manage_user where user_name = %s;' % add_str(manage_user_id))
            password_right = []
            for item in cursor.fetchall():
                password_right.append(item[0])
            if manage_user_password == password_right[0]:
                session_current = uuid4()
                session_current = str(session_current)
                cursor.execute('select user_name from session;')
                user_name = []
                for item in cursor.fetchall():
                    user_name.append(item[0])
                if manage_user_id in user_name:
                    cursor.execute('delete from session where user_name = %s;' % add_str(manage_user_id))
                    conn.commit()
                cursor.execute('insert into session values (%s, %s);' % (add_str(manage_user_id), add_str(session_current)))
                conn.commit()
                self.write(session_current)
            else:
                self.write("Error Password")
        else:
            self.write("User isn't existed")
        cursor.close()
        conn.close()

class UserRegister(tornado.web.RequestHandler):
    def post(self):
        user_name = self.get_argument('user_name').encode("UTF-8")
        manage_user_id = self.get_argument('manage_user_id').encode("UTF-8")
        user_work_num = self.get_argument('user_work_num').encode("UTF-8")
        user_sex = self.get_argument('user_sex').encode("UTF-8")
        user_phone_num = self.get_argument('user_phone_num').encode("UTF-8")
        session_current = self.get_argument('session').encode("UTF-8")
        combo_id = self.get_argument('combo_id').encode("UTF-8")
        parking_position_ID = self.get_argument('parking_position_id').encode("UTF-8")
        get_money = self.get_argument('get_money').encode("UTF-8")
        conn = mysql.connector.connect(user='root', password='1234', database='parking_place_manage_system', use_unicode=True)
        cursor = conn.cursor()
        cursor.execute('select user_name from session;')
        user_names = []
        for item in cursor.fetchall():
            user_names.append(item[0])
        if manage_user_id in user_names:
            cursor.execute('select session from session where user_name = %s;' % add_str(manage_user_id))
            session = []
            for item in cursor.fetchall():
                session.append(item[0])
            if session_current == session[0]:
                try:
                    cursor.execute('select free_hour, combo_money from card_combo where combo_ID = %s;' % add_str(combo_id))
                    free_hour = 0
                    combo_money = 0
                    for item in cursor.fetchall():
                        free_hour = item[0]
                        combo_money = item[1]
                    print combo_money
                    get_money = int(get_money) - int(combo_money)
                    cursor.execute('insert into fixed_card values (%s, %s, %s, %s, %s, 0);' % (add_str(user_work_num), add_str(parking_position_ID), get_money, free_hour, add_str(combo_id)))
                    conn.commit()
                    cursor.execute('insert into user values (\'%s\', \'e10adc3949ba59abbe56e057f20f883e\', %s, %s, %s);' % (user_name, add_str(user_work_num), add_str(user_sex), add_str(user_phone_num)))
                    conn.commit()
                    cursor.execute('update parking_position set is_belong = \'true\' where parking_position_ID = %s;' % add_str(parking_position_ID))
                    conn.commit()
                    cursor.execute('select parking_quality from parking_position where parking_position_ID = %s;' % add_str(parking_position_ID))
                    parking_quality = cursor.fetchall()
                    parking_quality2 = []
                    for item in parking_quality:
                        parking_quality2.append(item[0].encode("UTF-8"))
                    if parking_quality2[0] == 'temporary':
                        cursor.execute('update left_parking_place set left_number = left_number - 1, sum_number = sum_number - 1;')
                        conn.commit()
                        cursor.execute('update parking_position set parking_quality = \'temporary\' where parking_position_ID = %s;' % add_str(parking_position_ID))
                        conn.commit()
                    session_current = uuid4()
                    session_current = str(session_current)
                    self.write(session_current)
                    cursor.execute('update session set session = %s where user_name = %s;' % (add_str(session_current), add_str(manage_user_id)))
                    conn.commit()
                except:
                    self.write("Fail to Insert")
            else:
                self.write("Error")
        else:
            self.write("Error")
        cursor.close()
        conn.close()

class MoneyTimeSet(tornado.web.RequestHandler):
    def get(self):
        conn = mysql.connector.connect(user='root', password='1234', database='parking_place_manage_system', use_unicode=True)
        cursor = conn.cursor()
        cursor.execute('select * from card_combo;')
        get_combo = cursor.fetchall()
        return_data = []
        for item in get_combo:
            data = {'combo_id' : item[0].encode("UTF-8"),
                    'combo_name' : item[1].encode("UTF-8"),
                    'free_hour' : item[2],
                    'combo_money' : item[3],
                    'money_per_hour' : item[4]}
            return_data.append(data)
        return_data = json.dumps(return_data)
        self.write(str(return_data))
        cursor.close()
        conn.close()

class PayPage(tornado.web.RequestHandler):
    def post(self):
        card_num = self.get_argument('card_num').encode("UTF-8")
        get_money = self.get_argument('get_money').encode("UTF-8")
        manage_user_id = self.get_argument('manage_user_id').encode("UTF-8")
        session_current = self.get_argument('session').encode("UTF-8")
        conn = mysql.connector.connect(user='root', password='1234', database='parking_place_manage_system', use_unicode=True)
        cursor = conn.cursor()
        cursor.execute('select user_name from session;')
        current_time = datetime.datetime.now()
        user_names = []
        for item in cursor.fetchall():
            user_names.append(item[0])
        if manage_user_id in user_names:
            cursor.execute('select session from session where user_name = %s;' % add_str(manage_user_id))
            session = []
            for item in cursor.fetchall():
                session.append(item[0])
            if session_current == session[0]:
                cursor.execute('select card_num from fixed_card;')
                fixed_card_list = []
                for item in cursor.fetchall():
                    fixed_card_list.append(item[0])
                if card_num not in fixed_card_list:
                    self.write("Error")
                    return
                if get_money == "":
                    cursor.execute('select card_money from fixed_card where card_num = %s' % add_str(card_num))
                    card_money = []
                    for item in cursor.fetchall():
                        card_money.append(item[0])
                    card_money = float(card_money[0])
                    return_data = [{'left_money' : card_money}]
                    cursor.execute('select car_num, arrive_time, leave_time, using_time,get_money from card_record where card_num = %s' % add_str(card_num))
                    for item in cursor.fetchall():
                        data = {}
                        data['car_num'] = item[0]
                        data['arrive_time'] = item[1]
                        data['leave_time'] = item[2]
                        data['using_time'] = item[3]
                        data['get_money'] = item[4]
                        leave_time = datetime.datetime.strptime(data['leave_time'], "%Y-%m-%d %H:%M:%S")
                        if leave_time.year == current_time.year and leave_time.month == current_time.month:
                            return_data.append(data)
                    return_data = json.dumps(return_data)
                    self.write(str(return_data))
                else:
                    get_money = float(get_money)
                    cursor.execute('select card_money from fixed_card where card_num = %s' % add_str(card_num))
                    for item in cursor.fetchall():
                        get_money += float(item[0])
                    cursor.execute('update fixed_card set card_money = %s where card_num = %s' % (get_money, add_str(card_num)))
                    conn.commit()
                    self.write("update successful")
            else:
                self.write("Error")
        else:
            self.write("Error")
        cursor.close()
        conn.close()

class GetParking(tornado.web.RequestHandler):
    def get(self):
        conn = mysql.connector.connect(user='root', password='1234', database='parking_place_manage_system', use_unicode=True)
        cursor = conn.cursor()
        cursor.execute('select parking_position_ID, parking_describe from parking_position where parking_quality = \'fixed\' and is_belong = \'false\';')
        get_data = cursor.fetchall()
        return_data = []
        for item in get_data:
            data = {
                'parking_id' : item[0].encode("UTF-8"),
                'parking_describe' : item[1].encode("UTF-8")
            }
            return_data.append(data)
        if len(return_data) == 0:
            cursor.execute('select parking_position_ID, parking_describe from parking_position where parking_quality = \'temporary\' and is_belong = \'false\';')
            get_data = cursor.fetchall()
            for item in get_data:
                data = {
                    'parking_id' : item[0].encode("UTF-8"),
                    'parking_describe' : item[1].encode("UTF-8")
                }
                return_data.append(data)
        return_data = json.dumps(return_data)
        self.write(str(return_data))
        cursor.close()
        conn.close()

class GetAllTemporaryData(tornado.web.RequestHandler):
    def get(self):
        conn = mysql.connector.connect(user='root', password='1234', database='parking_place_manage_system', use_unicode=True)
        cursor = conn.cursor()
        cursor.execute('select card_num from temporary_card;')
        temporary_card_num = []
        for item in cursor.fetchall():
            temporary_card_num.append(item[0])
        cursor.execute('select * from card_record')
        return_data = []
        for item in cursor.fetchall():
            data = {}
            if item[0] in temporary_card_num:
                data['card_num'] = item[0]
                data['car_num'] = item[1]
                data['arrive_time'] = item[2]
                data['leave_time'] = item[3]
                data['using_time'] = item[4]
                data['get_money'] = item[5]
                return_data.append(data)
        return_data = json.dumps(return_data)
        self.write(str(return_data))

class GetTemporaryData(tornado.web.RequestHandler):
    def post(self):
        manage_user_id = self.get_argument('manage_user_id').encode("UTF-8")
        session_current = self.get_argument('session').encode("UTF-8")
        year = self.get_argument('year').encode("UTF-8")
        month = self.get_argument('month').encode("UTF-8")
        day = self.get_argument('day').encode("UTF-8")
        year = int(year)
        month = int(month)
        day = int(day)
        conn = mysql.connector.connect(user='root', password='1234', database='parking_place_manage_system', use_unicode=True)
        cursor = conn.cursor()
        cursor.execute('select user_name from session;')
        user_names = []
        for item in cursor.fetchall():
            user_names.append(item[0])
        if manage_user_id in user_names:
            cursor.execute('select session from session where user_name = %s;' % add_str(manage_user_id))
            session = []
            for item in cursor.fetchall():
                session.append(item[0])
            if session_current == session[0]:
                cursor.execute('select card_num from temporary_card;')
                temporary_card_num = []
                for item in cursor.fetchall():
                    temporary_card_num.append(item[0])
                cursor.execute('select * from card_record')
                return_data = []
                for item in cursor.fetchall():
                    data = {}
                    if item[0] in temporary_card_num:
                        data['card_num'] = item[0]
                        data['car_num'] = item[1]
                        data['arrive_time'] = item[2]
                        data['leave_time'] = item[3]
                        data['using_time'] = item[4]
                        data['get_money'] = item[5]
                        leave_time = datetime.datetime.strptime(data['leave_time'], "%Y-%m-%d %H:%M:%S")
                        if leave_time.year == year and month == 0 and day == 0:
                            return_data.append(data)
                        elif leave_time.year == year and month == leave_time.month and day == 0:
                            return_data.append(data)
                        elif leave_time.year == year and month == leave_time.month and day == leave_time.day:
                            return_data.append(data)
                return_data = json.dumps(return_data)
                self.write(str(return_data))

class Application(tornado.web.Application):
    def __init__(self):
        handlers = [
            (r"/inoutlogin", InOutLoginHandler),
            (r"/countparking", ParkingCountHandler),
            (r"/inoutcommitcard", InOutCommitCard),
            (r"/inoutloginout", OutInLogin),
            (r"/managelogin", ManageLogin),
            (r"/userregister", UserRegister),
            (r"/timemoneyset", MoneyTimeSet),
            (r"/paypage", PayPage),
            (r"/getparking", GetParking),
            (r"/alltemporarydata", GetAllTemporaryData),
            (r"/temporarydata", GetTemporaryData),
        ]
        tornado.web.Application.__init__(self, handlers)

record = []
if __name__ == "__main__":
    tornado.options.parse_command_line()
    app = Application()
    http_server = tornado.httpserver.HTTPServer(app)
    http_server.listen(options.port)
    tornado.ioloop.IOLoop.instance().start()