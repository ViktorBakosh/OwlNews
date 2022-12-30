# Load library
import pandas as pd
import demoji
import json

# Environment settings: 
pd.set_option('display.max_rows', None)
pd.set_option('display.max_colwidth', 210)

with open('Data_set\data\Sluthba_bezpeky_Ukrainy.json', encoding='utf-8') as json_file:
    data = json.load(json_file)
print('\nDone Loading Sluthba_bezpeky_Ukrainy.json\n')

#make True news column
i = 0
text = []
k = 0
cities = ['Одещині','Донецькій області','У Харківській області','У Закарпатській області','У Дніпрі:','У Києві:','У Миколаєві:','У Миколаєві:','У Луганській області:','У Сєвєродонецьку:','У Закарпатській області:','У Вінницькій області:','У Дніпропетровській області:',]
while(True):
    try:
        buffer = ''
        j = 0
        if('щотижневій' in data['messages'][i]['text']):
            try:
                for k in range(len(data['messages'][i]['text_entities'])):
                    if ('🔹' or '🔸' or '�') in data['messages'][i]['text_entities'][k]['text']:
                        buffer += (data['messages'][i]['text_entities'][k]['text'].replace("\n" or '\\' or '�', ' '))
                        text.append(demoji.replace(buffer.strip(), ""))
            except:
                i+=1
                continue
        elif(data['messages'][i]['text'] == ''):
            i+=1
            continue
        # if('🔹 У' in data['messages'][i]['text_entities']):      buged part: can't see '🔹 У' in json file
        #     for k in range(len(data['messages'][i]['text_entities'])):
        #         try:
        #             if '🔹' in data['messages'][i]['text_entities'][k]['text']:
        #                 buffer += (data['messages'][i]['text_entities'][k]['text'].replace("\n" or '\\' or '�', ' '))
        #                 demoji.replace(buffer.strip(), "")
        #                 w = buffer.split('🔹')
        #                 w.pop(0)
        #                 for l in range(len(w)):
        #                     text.append(w[l])
        #                 print(w)
        #         except:
        #             i+=1
        #             continue
        elif(str(data['messages'][i]['text_entities'][0]['type']) == 'bold'):
            text.append(((data['messages'][i]['text_entities'][0]['text']).replace('\n' or '\\' or '�', '')))
            i+=1
            continue  
        i+=1
    except: 
        print('\n\nend of JSON file\n\n')
        break
dataframe = pd.DataFrame(text, columns=['Text'])
dataframe['Label'] = 'True'
dataframe['Text'].str.strip()
print(dataframe)
print('\n\n\n\n')
#dataframe.to_csv('Data_set/data/Sluthba_bezpeky_Ukrainy_1.csv')