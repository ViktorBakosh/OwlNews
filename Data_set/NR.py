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
with open('Data_set/data/NR.json', encoding='utf-8') as json_file:
    NR = json.load(json_file)
print('\nDone Loading NR.json\n')

#NR news 

i = 0
text = []
links = []
false_words = ['Миноборон' , 'миноборон' ,'Глав' , 'глав', 'фейк']
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
            if 'Украин' in str(NR['messages'][i]['text_entities']) :
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
                if not any(value for value in false_symbols if value in buffer[0]):
                    buffer_into_words = buffer.split(' ')
                    if not any(value for value in false_words if value in buffer_into_words):
                        if ':' not in buffer:
                            buffer = demoji.replace(buffer, "")
                            print(buffer)
                            text.append(buffer)
                            link += 'https://t.me/nrpublic/' + str(NR['messages'][i]['id'])
                            links.append(link)
        i+=1
        continue
    except: 
        print('\n\nend of JSON file\n\n')
        break

#handing found useless news to delete      
useless_news = [

]

text_cleared = [x for x in text if x not in useless_news]
print(len(text_cleared))

# translate = []
# translator = Translator()
# try:
#     for element in range(len(text)):
#         translate.append((translator.translate(text[element], src='ru', dest='uk')).text)
# except Exception as e:
#         print('\n\n',e)

# #make dataframe and save as csv
# dataframe = pd.DataFrame()
# dataframe['Link'] = links
# dataframe['Text'] = translate
# dataframe['Text']
# dataframe['Label'] = 'True'
# print(dataframe)
# print('\n\n\n\n')
# #dataframe.to_csv('Data_set/data/NR_verified.csv')