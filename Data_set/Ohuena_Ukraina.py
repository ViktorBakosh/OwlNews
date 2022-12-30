# Load library
import pandas as pd
import demoji
import json
from googletrans import Translator

# Environment settings: 
pd.set_option('display.max_rows', None)
pd.set_option('display.max_colwidth', 210)

with open('Data_set\data\Ohuena_Ukraina.json', encoding='utf-8') as json_file:
    data = json.load(json_file)
print('\nDone Loading Ohuena_Ukraina.json\n')

#make True news column
i = 0
k = 0
text = []
while(True):
    try:
        buffer = ''
        j = 0
        if(data['messages'][i]['text'] == ''):
            i+=1
            continue
        elif(str(data['messages'][i]['text_entities'][0]['type']) == 'bold'):
            for k in range(len(data['messages'][i]['text_entities'])):
                    if data['messages'][i]['text_entities'][k]['type'] == 'bold':
                        buffer += (data['messages'][i]['text_entities'][k]['text']).replace('\n' or '\\' or '�', ' ')
            if (len(buffer) > 40) and (buffer[0] != '"') and ((':' or 'втрати противника') not in buffer):
                text.append(demoji.replace(buffer, ""))
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
except Exception as e:
        print('\n\n',e)

#make dataframe and save as csv
dataframe = pd.DataFrame(translate, columns=['Text'])
dataframe['Label'] = 'True'
dataframe['Text'].str.strip()
print(dataframe)
print('\n\n\n\n')
dataframe.to_csv('Data_set/data/Ohuena_Ukraina.csv')