# Load library
import pandas as pd
import demoji
from googletrans import Translator
import json

# Environment settings: 
pd.set_option('display.max_rows', None)
pd.set_option('display.max_colwidth', 250)
pd.set_option('display.max_colwidth', 250)

#open file
with open('Data_set/data/NR_news.json', encoding='utf-8') as json_file:
    NR = json.load(json_file)
print('\nDone Loading NR.json\n')

#NR news 

i = 0
text = []
Fake_news = []
links = []
fake_links = []
false_words = ['Миноборон' , 'миноборон' ,'Глав' , 'глав', 'фейк', 'РФ']
Fake_news_words = ['Минобороны РФ' ,'Чижов' ,'Минобороны России' ,'Лукашенко' ,'ФСБ' ,'Медведев' ,'Нарышкин' ,'Песков' ,'Захарова' ,'Кремль' ,'— Путин' ,'Путин:' ,'Шойгу' ,'Лавров' ,'[Роскомнадзор]']
false_symbols = ['«' , '"']
#print(('Лукашен' or 'Путин') in str(NR['messages'][1]['text_entities']))
#and ('Миноборон' or 'миноборон' or 'Глав' or 'глав' or 'фейк') not in str(NR['messages'][i]['text_entities'])
while(True):
    try:
        if(NR['messages'][i]['text'] == ''):
            i+=1
            continue
        elif(str(NR['messages'][i]['text_entities'][0]['text'])):
            j = 0
            buffer = ''
            link = ''
            if ('Украин' or 'Росс' or 'украин' or 'росс') in str(NR['messages'][i]['text_entities']) :
                while(True):
                    try:
                        buffer += (NR['messages'][i]['text_entities'][j]['text']).replace('\n' or '\\', ' ')
                        j+=1
                    except:
                        break
                buffer = demoji.replace(buffer, "")
                if (len(buffer) > 200):
                    i+=1
                    continue 
            if(len(buffer) > 40):
                if buffer[0] not in false_symbols:
                    false = 0
                    fake = 0
                    for word in false_words:
                        if word in buffer:
                            false = 1
                    if false == 0:
                        for word in Fake_news_words:
                            if word in buffer:
                                fake = 1
                        if fake == 0:  
                            print(buffer)
                            text.append(buffer)
                            link += 'https://t.me/nrpublic/' + str(NR['messages'][i]['id'])
                            links.append(link)
                        else: 
                            Fake_news.append(buffer)
                            link += 'https://t.me/nrpublic/' + str(NR['messages'][i]['id'])
                            fake_links.append(link)
        i+=1
        continue
    except: 
        print('\n\nend of JSON file\n\n')
        break

# print(Fake_news,'\n\n\n\n\n')
# print(text,'\n\n\n\n\n')
print(len(Fake_news) , len(fake_links))
print(len(text) , len(links))

translate_True = []
translate_Fake = []
translator = Translator()
try:
    for element in range(len(text)):
        translate_True.append((translator.translate(text[element], src='ru', dest='uk')).text)
except Exception as e:
        print('\n\n',e)

try:
    for element in range(len(Fake_news)):
        translate_Fake.append((translator.translate(Fake_news[element], src='ru', dest='uk')).text)
except Exception as e:
        print('\n\n',e)


#make dataframe and save as csv
dataframe_true = pd.DataFrame()
dataframe_true['Link'] = links
dataframe_true['Text'] = translate_True
dataframe_true['Label'] = 'True'
print(dataframe_true)
print('\n\n\n\n')
dataframe_true.to_csv('Data_set/data/verified_datasets/NR_True_verified.csv')

#make dataframe and save as csv
dataframe_fake = pd.DataFrame()
dataframe_fake['Link'] = fake_links
dataframe_fake['Text'] = translate_Fake
dataframe_fake['Label'] = 'False'
print(dataframe_fake)
print('\n\n\n\n')
dataframe_fake.to_csv('Data_set/data/verified_datasets/NR_Fake_verified.csv')