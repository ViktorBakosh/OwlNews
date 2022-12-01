# Load library
import pandas as pd
import demoji
from googletrans import Translator
import json

# Environment settings: 
pd.set_option('display.max_rows', None)a
pd.set_option('display.max_colwidth', 250)
pd.set_option('display.max_colwidth', 250)

#open file
with open('Data_set/data/NR.json', encoding='utf-8') as json_file:
    NR = json.load(json_file)
print('\nDone Loading NR.json\n')

#NR news 

i = 0
text = []
#print(('Лукашен' or 'Путин') in str(NR['messages'][1]['text_entities']))
while(True):
    try:
        if(NR['messages'][i]['text'] == ''):
            i+=1
            continue
        elif(str(NR['messages'][i]['text_entities'][0]['text'])):
            j = 0
            buffer = ''
            if 'Украин' in str(NR['messages'][i]['text_entities']) and ('Миноборон' or 'миноборон' or 'Глав' or 'глав' or 'фейк') not in str(NR['messages'][i]['text_entities']):
                while(True):
                    try:
                        buffer += (NR['messages'][i]['text_entities'][j]['text']).replace('\n' or '\\', ' ')
                        j+=1
                    except:
                        break
                text.append(demoji.replace(buffer, ""))
        i+=1
        continue
    except: 
        print('\n\nend of JSON file\n\n')
        break
dataframe = pd.DataFrame(text, columns=['Text'])
dataframe['Label'] = 'True'
dataframe['Text'].str.strip()
print('\n\n\n\n')
print(dataframe)
dataframe.to_csv('NR_news.csv')