# Load library
import pandas as pd
import demoji
from googletrans import Translator
import json

# Environment settings: 
pd.set_option('display.max_rows', None)
pd.set_option('display.max_colwidth', 280)
pd.set_option('display.max_colwidth', 280)

#open file
with open('Data_set/data/suspilne.json', encoding='utf-8') as json_file:
    suspilne = json.load(json_file)
print('\nDone Loading suspilne.json\n')

#NR news 

i = 0
text = []
#print(('Лукашен' or 'Путин') in str(NR['messages'][1]['text_entities']))
while(True):
    try:
        if(suspilne['messages'][i]['text'] == ''):
            i+=1
            continue
        elif(str(suspilne['messages'][i]['text_entities'][0]['text'])):
            buffer = ''
            j=0
            if 'новини ранку' in str(suspilne['messages'][i]['text_entities']):
                while('новини ранку' not in suspilne['messages'][i]['text_entities'][j]['text']):
                        j+=1
                j+=1
                while(True):
                    #if('🔹' not in suspilne['messages'][i]['text_entities'][j]['text']):
                    try:
                        buffer += (suspilne['messages'][i]['text_entities'][j]['text']).replace('\n' or '\\', ' ')
                        #print(buffer)
                        j+=1
                    except:
                        break
                buffer = buffer.split('🔹')
                for k in range(len(buffer)):
                    try:
                        if len(buffer[k]) < 5:
                            continue
                        text.append(demoji.replace(buffer[k], ""))
                    except:
                        break
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
dataframe.to_csv('Data_set/data/suspilne_news.csv')