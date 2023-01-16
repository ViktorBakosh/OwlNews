# Load library
import pandas as pd
import demoji
from googletrans import Translator
import json

# Environment settings: 
pd.set_option('display.max_rows', None)
pd.set_option('display.max_colwidth', 210)

with open('Data_set/data/Novosti_Ukrainy_Online.json', encoding='utf-8') as json_file:
    data = json.load(json_file)
print('\nDone Loading Novosti_Ukrainy_Online.json\n')

#make True news column
i = 0
text = []
links = []
false_words = ['СБУ' , 'Фото' ,'фото' , 'відео', 'Відео','⚠️','❗','🔴','💥',]
false_symbols = ['«' , '"']
while(True):
    try:
        if(data['messages'][i]['text'] == ''):
            i+=1
            continue
        j=0
        buffer = ''
        link = ''
        while(str(data['messages'][i]['text_entities'][j]['type']) == 'bold' ):
            buffer += (data['messages'][i]['text_entities'][j]['text']).replace('\n' or '\\' or '�', '')
            if ('«' and '»') in buffer:
                buffer += (data['messages'][i]['text_entities'][j+1]['text']).replace('\n' or '\\' or '�', '')
            j+=1
        # if (buffer != '' and len(buffer) > 40) and (('⚠️' and '❗' and '🔴' and '🔴' and '💥') not in buffer):
        #     text.append(demoji.replace(buffer.strip(), ""))
        if (len(buffer) > 200):
            i+=1
            continue
        if(len(buffer) > 40):
            if not any(value for value in false_symbols if value in buffer[0]):
                buffer_into_words = buffer.split(' ')
                if not any(value for value in false_words if value in buffer_into_words):
                    if ':' not in buffer:
                        text.append(demoji.replace(buffer, ""))
                        link += 'https://t.me/perepichka_news/' + str(data['messages'][i]['id'])
                        links.append(link)
        i+=1
    except: 
        print('\n\nend of JSON file\n\n')
        break
translate = []
translator = Translator()
#drop useless data (hand droping)
#useless_data = [0,11,14,17,83,98,1395,20,21,36,406,1577,1725,1603,27,190,1673,1907,1932,2035,32,33,34,263,406,35,127,1051]
try:
    for element in range(len(text)):
        translate.append((translator.translate(text[element], src='ru', dest='uk')).text)
except Exception as e:
        print('\n\n',e)
        
#make dataframe and save as csv        
dataframe = pd.DataFrame()
dataframe['Link'] = links
dataframe['Text'] = translate
dataframe['Text'].str.strip()
dataframe['Label'] = 'True'
#dataframe.drop(useless_data)
print(dataframe)
print('\n\n\n\n')
#dataframe.to_csv('Data_set/data/Novosti_Ukrainy_Online_verified.csv')