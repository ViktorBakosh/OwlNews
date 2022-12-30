# Load library
import pandas as pd
import demoji
from googletrans import Translator
import json
from fake_news_from_russian_chanel import import_data_from_site #use function from another python file

# Environment settings: 
pd.set_option('display.max_rows', None)
pd.set_option('display.max_colwidth', 140)

with open('Data_set/data/fake_news_on_russian_language.json', encoding='utf-8') as json_file2:
    data2 = json.load(json_file2)
print('\nDone Loading fake_news_on_russian_language.json\n')

#make Fake news column
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

#translate russian news into ukrainian language
translate = []
translator = Translator()
try:
    for element in range(len(text2)):
        translate.append((translator.translate(text2[element], src='ru', dest='uk')).text)
        print(((translator.translate(text2[element], src='ru', dest='uk')).text))
except Exception as e:
        print('\n\n',e)
dataframe2 = pd.DataFrame(text2, columns=['Text'])
dataframe2['Label'] = 'False'

#add another 222 fake examples 
site_fakes = import_data_from_site()
dataframe_buff = pd.DataFrame(site_fakes, columns=['Text'])
dataframe_buff['Label'] = 'False'

#concatenate 2 fakes
fake_news = pd.concat([dataframe_buff, dataframe2], axis=0)
print('\n\n\n\n')
print(fake_news)

print('\n\n\n\n',"end of russian news")
fake_news.to_csv('Data_set\data\csv_files\Russian_fake_news.csv')

# print('\n\n\n\n')
# print(dataframe,"end of TSN_news_true")
# dataframe.to_csv('Data_set/data/TSN_news_true.csv')
