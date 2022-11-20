# Load library
import pandas as pd
import demoji
from googletrans import Translator
import json

# Environment settings: 
pd.set_option('display.max_rows', None)
pd.set_option('display.max_colwidth', 140)

with open('Data_set/TSN_news_true.json', encoding='utf-8') as json_file:
    data = json.load(json_file)
print('\nDone Loading TSN_news_true.json\n')
with open('Data_set/fake_news_on_russian_language.json', encoding='utf-8') as json_file2:
    data2 = json.load(json_file2)
print('\nDone Loading fake_news_on_russian_language.json\n')

i = 0
text = []
while(True):
    try:
        if(data['messages'][i]['text'] == ''):
            i+=1
            continue
        elif(str(data['messages'][i]['text_entities'][0]['text'])):
            j = 0
            buffer = ''
            while(True):
                try:
                    buffer += (data['messages'][i]['text_entities'][j]['text']).replace('\n' or '\\', '')
                    j+=1
                except:
                    break
            text.append(demoji.replace(buffer.strip(), ""))
            i+=1
            continue
    except: 
        print('\n\nend of JSON file\n\n')
        break
dataframe = pd.DataFrame(text, columns=['Text'])
dataframe['Label'] = 'True'
dataframe['Text'].str.strip()
print('\n\n\n\n')
#print(text)
i = 0
text2 = []
while(True):
    try:
        if(data2['messages'][i]['text_entities'] == []):
            i+=1
            continue
        elif ('Фейк' or 'фейк') in data2['messages'][i]['text_entities'][0]['text']:
            buffer2 = ''
            j=1
            try:
                while('Правда' not in data2['messages'][i]['text_entities'][j]['text']):
                    buffer2 += (data2['messages'][i]['text_entities'][j]['text']).replace('\n', '')
                    j+=1
            except:
                i+=1
                continue
            buffer2 = buffer2.strip()
            text2.append(demoji.replace(buffer2, ""))
        i+=1
    except:
        print('\n\nend of JSON file\n\n')
        break
translate = []
translator = Translator()
try:
    for element in range(len(text2)):
        translate.append((translator.translate(text2[element], src='ru', dest='uk')).text)
except Exception as e:
        print('\n\n',e)
dataframe2 = pd.DataFrame(translate, columns=['Text'])
dataframe2['Label'] = 'False'
print('\n\n\n\n')
print(dataframe2)
result = pd.concat([dataframe, dataframe2], axis=0)
result = result.sample(frac=1).reset_index(drop=True)
print(result)
print('\n\n\n\n',"end")
result.to_csv('news_data.csv')

