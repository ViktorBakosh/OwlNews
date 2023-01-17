# Load library
import pandas as pd
import demoji
import json
from googletrans import Translator
# Environment settings: 
pd.set_option('display.max_rows', None)
pd.set_option('display.max_colwidth', 210)

with open('Data_set\data\Perepichka_NEWS.json', encoding='utf-8') as json_file:
    data = json.load(json_file)
print('\nDone Loading Perepichka_NEWS.json\n')

#make True news column
i = 0
text = []
links = []
false_words = [ 'СБУ' , 'Фото' ,'фото' , 'видео', 'Видео', 'Последствия', 'Вот' ]
false_symbols = ['«' , '"']
while(True):
    try:
        buffer = ''
        link = ''
        if(data['messages'][i]['text'] == ''):
            i+=1
            continue
        elif('bold' in str(data['messages'][i])):
            for k in range(len(data['messages'][i]['text_entities'])):
                if data['messages'][i]['text_entities'][k]['type'] == 'bold':
                    buffer += (data['messages'][i]['text_entities'][k]['text']).replace('\n' or '\\' or '�', ' ')
            buffer = demoji.replace(buffer, "")
            if (len(buffer) > 200):
                i+=1
                continue
            if(len(buffer) > 40):
                buffer_into_words = buffer.split(' ')
                if not any(value for value in false_symbols if value in buffer[0]): #buffer[0] != ('«' or '"')
                    if not any(value for value in false_words if value in buffer_into_words):
                        if(':' not in buffer):
                            #print(buffer[0],'\t',buffer)
                            text.append(buffer)
                            link += 'https://t.me/perepichka_news/' + str(data['messages'][i]['id'])
                            links.append(link)
        i+=1
        continue  
    except: 
        print('\n\nend of JSON file\n\n')
        break

#handing found useless news to delete  
useless_news = [
'Они защищают нас на фронте, мы обеспечиваем их в тылу'
,'Спецагент Гиркин о ситуации в Херсонской области'
,'Первые секунды после взрыва на благотворительной ярмарке в Чернигове'
,'Спецагент Гиркин о ситуации в Херсонской области'
,'погибли 2 человека ещё 5 получили ранения'
,'Что известно о противостоянии на Харьковском направлении,Балаклея в оперативном окружении'
,'но призываем набраться терпения и дождаться официальной информациитишина может спасти жизнь наших воинов'
,'В Москве началось?  С отправить Путина в отставку и обвинить его в госизмене'
,'✙ Что значит белый крест на нашей военной технике?  Символ'
,'Первый официальный комментарий о ситуации со светом'
,'Российский "Орлан" – как дирижабль в небе'
,'сорвать наступление ВСУ на Херсонском направлении'
,'кадры  в Херсоне, которую ведет российская техника'
,'Первый день без мамы, посмотрите на его костюм'
,'Угрозу можно ликвидировать только силой'
,'не только мобилизацию и подписал указ с секретным пунктом'
,'Поговорим о ядерном ударе на сон грядущий  рф,'
,'ак один из протестующих въехал в толпу полицейских'
,'Україна - ШотландіяЗабирай бонус 2500грн від Parimatch за посиланням нижче, роби гру ще цікавішою та підтримуй збірну !Тисни на кнопку та бери участь у розіграші футболки з автографом Мудрика!'
,'там снова заговорили о новом федеральном округе, который будет состоять из оккупированных территорий Украины'
,'получит 18 новых HIMARS, 150 внедорожников, радары и системы противодействия БПЛА$1,1 млрд'
,'Так вот для чего русне нужны были  43-го года'
,'- Какой выход из конфликта? - Выход из конфликта - это чтобы россия покинула Украин'
,'А вот и подарки иимениннику - трактор и дыни'
,'Нет слов. Кремлевское существо никак не угомонится'
,'российская линия обороны в Луганской области.'
,'Хочешь жить? Извини, но ты живешь в россии'
,'1xBetцибин сергей и родин александрФСБ и ГРУцибин, родин'
,'Эти лица должен увидеть весь мир  ЗМ-14 («Калибр»9М728 (он же Р-500Х-101'
,'Селтік - ШахтарЗабирай бонус 2500 грн від Parimatch - титульного партнера ФК Шахтар за посиланням нижче, роби гру ще цікавішою!Вболівай серцем — грай головою!'
,'Дыров назвал войну против Украины джихадомс'
,'1xBetTECHIIA1xBet (ТОВ «ТБК») александр родинWEPLAY (TECHIIA) .TECHIIAолег крот'
,'путин выступает с "очень интересными" заявлениями'
,'Олег КротTECHIIAФинальной суммы я не знаю'
,'анонсировал обмен пленными по формуле 107 на 107'
,'TECHIIA1xBetКРАИЛ1xBet1xBetTECHIIAКРАИЛКРАИЛ'
,'Рот путина песков о визите Зеленского в Херсон'
,'конфисковать активы России в ЕС в пользу Украины'
,'РОЗІГРУЄМО ТА СОНЯЧНИЙ ПОВЕРБАНК + 2200 FS  2 грудня'
,'1xBet, BetWinner, Melbet, Fansport, PointLoto Не становитесь предателями, ваши дети вам не простят!']
text_cleared = [x for x in text if x not in useless_news]
print(text_cleared,'\n\n',len(text_cleared))

#translate russian news into ukrainian language
translate = []
translator = Translator()
try:
    for element in range(len(text)):
        translate.append((translator.translate(text[element], src='ru', dest='uk')).text)
        print(translate[element])
except Exception as e:
        print('\n\n',e)

#make dataframe and save as csv
dataframe = pd.DataFrame()
dataframe['Link'] = links
dataframe['Text'] = translate
dataframe['Label'] = 'True'
print(dataframe)
print('\n\n\n\n')
dataframe.to_csv('Data_set/data/csv_files/Perepichka_NEWS_verified.csv')