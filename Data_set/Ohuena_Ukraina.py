# Load library
import pandas as pd
import demoji
import json
from googletrans import Translator
import socket
# Environment settings: 
socket.getaddrinfo('localhost', 8080)
pd.set_option('display.max_rows', None)
pd.set_option('display.max_colwidth', 210)

with open('Data_set\data\Ohuena_Ukraina.json', encoding='utf-8') as json_file:
    data = json.load(json_file)
print('\nDone Loading Ohuena_Ukraina.json\n')

#make True news column
i = 0
text = []
links = []
false_words = ['СБУ' , 'Фото' ,'фото' , 'видео', 'Видео', 'втрати', 'Общие'] #, 'Вот' , 'Последствия' , 'бойові вирати'
false_symbols = ['«' , '"']
while(True):
    try:
        buffer = ''
        link = ''
        if(data['messages'][i]['text'] == ''):
            i+=1
            continue
        elif(str(data['messages'][i]['text_entities'][0]['type']) == 'bold'):
            for k in range(len(data['messages'][i]['text_entities'])):
                if data['messages'][i]['text_entities'][k]['type'] == 'bold':
                    buffer += (data['messages'][i]['text_entities'][k]['text']).replace('\n' or '\\' or '�', ' ')
            buffer = demoji.replace(buffer, "")
            if (len(buffer) > 200):
                i+=1
                continue
            if len(buffer) > 40:
                buffer_into_words = buffer.split(' ')
                if not any(value for value in false_symbols if value in buffer[0]): #buffer[0] != ('«' or '"')
                    if not any(value for value in false_words if value in buffer_into_words):
                        if ':' not in buffer:
                            print(buffer)
                            text.append(demoji.replace(buffer, ""))
                            link += 'https://t.me/c/1376264484/' + str(data['messages'][i]['id'])
                            links.append(link)
        i+=1
        continue  
    except: 
        print('\n\nend of JSON file\n\n')
        break

#handing found useless news to delete  
useless_news = [
'По мосту в Херсоне "бросили один единственный камушек",'
,'Реакция украинцев на "возгорания" в Крыму'
,'Вечірнє звернення президента Володимира Зеленського.'
,'Хейтеры скажут фотошоп, но мы то знаем правду'
,'Сводка по потерям оккупантов от Генштаба ВСУ.'
,'Вечірнє звернення Володимира Зеленського.  "'
,'Арестович оценил угрозу наступления белорусской армии.'
,'День Независимости нашей Державы УКРАИНА!    Слава Україні!'
,'В -12° остались без газа, воды, света и связи'
,'Очередная "высокоточная" яма за 5 миллионов долларов.Привіт від місцевих з Скадовську та Генічеську'
,'Привіт від місцевих з Скадовську та Генічеську'
,'Звернення Президента Володимира Зеленського наприкінці 190-го дня війни'
,'Ще одного рідкісного звіра вполювали наші захисники'
,'ЄС зняв з Януковича і його сина Олександрачастину санкцій'
,'У прикордонному пункті орків хтось підкурив'
,'Активність ворожої авіації в акваторії Азовського моря.'
,'Карта повітряних тривог зараз. Залишайтеся в укриттях.'
,'Ну що, налаштувались на спробу путіна щось сказати своїй недонації?'
,'Объясню русским по-русски, что происходит'
,'Ось таку ціну доведеться заплатити за втечу з рашки'
,'Ось так відбувається "референдум" у Маріуполі,'
,'"Там уже, если что, в россии чуть ли не переворот идёт",'
,'А ось так зараз виглядає Антонівський міст'
,'Ещё раз хочу сказать для русских по-русски.'
,"Що робити, якщо раптом зникне мобільний зв'язок"
,'Хейтеры скажут фотошоп, но мы то знаем правду'
,'Повітряна тривога у низці областей України!'
,'Іще один вибух в Шевченківському районі,'
,'Віримо тільки ЗСУ, пам‘ятаємо ціну свободи'
,'НАТО на росії перемогли, а от алкоголізм…'
,'Картопляний спецназ Лукашенко їздить із гастролями в рамках циркового шоу'
,'Патрульна поліція полонила групу мобіків'
,'Обращение координатора "Желтой ленты" в Крыму к народу Украиныи только сейчас начинается это изменение в сознании'
,'Зеленський назвав найбільшу помилку України'
,'Підписуйтесь на воїна з 25 Десантно Штурмової бригади'
,'Карта російських ракетних ударів по Україні на даний момент'
,'У Офісі президента відреагували на обстріли рашистів'
,'Вечірнє звернення президента Володимира Зеленського.'
,'Завтра по всій Україні вимикатимуть світло за плановими графіками,'
,'Українки передали главі Пентагону Ллойду Остінупрапор з Херсонщини'
,'Звернення Президента Володимира Зеленського наприкінці 190-го дня війни'
,'Кременчуцький р-н (Полтавщина) — вибухи.'
,'Посмотрите, что вы наделали своими донатамиVARTA и дрон Mavic 3  собрали 161 169 грн (!)  .  Вместе победим!'
,'Вам також здається, що росія засиділася в лавах держав-членів ООН?'
,'Втрати російської армії за 9 місяців повномасштабної війни'
,'Супутникові знімки Maxar укріплень рашистів на лівобережжі Херсонщини'
,'Уламок боєприпасу русні ледь не влучив у серце'
,'Звернення Володимира Зеленського наприкінці 198-го дня війни.'
,'Вечірнє звернення Володимира Зеленського.  "'
,'Неймовірний кадр. Російська куля застрягла у шкірі голови нашого Воїна.'
]
text_cleared = [x for x in text if x not in useless_news]
print(len(text))

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
dataframe.to_csv('Data_set/data/Ohuena_Ukraina_verified.csv')