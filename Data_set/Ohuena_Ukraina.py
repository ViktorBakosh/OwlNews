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
k = 0
text = []
links = []
false_words = ['СБУ' , 'Фото' ,'фото' , 'відео', 'Відео', 'втрати']
false_symbols = ['«' , '"']
while(True):
    try:
        buffer = ''
        link = ''
        j = 0
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
                if not any(value for value in false_symbols if value in buffer[0]):
                    buffer_into_words = buffer.split(' ')
                    if not any(value for value in false_words if value in buffer_into_words):
                        if ':' not in buffer:
                            text.append(demoji.replace(buffer, ""))
                            link += 'https://t.me/c/1376264484/' + str(data['messages'][i]['id'])
                            links.append(link)
        i+=1
        continue  
    except: 
        print('\n\nend of JSON file\n\n')
        break

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
dataframe['Text'].str.strip()
dataframe['Label'] = 'True'
print(dataframe)
print('\n\n\n\n')
# dataframe.to_csv('Data_set/data/Ohuena_Ukraina_verified.csv')