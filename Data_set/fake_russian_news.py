# Load library
import pandas as pd
import demoji
from googletrans import Translator
import json
from fake_news_from_russian_chanel import import_data_from_site #use function from another python file

# Environment settings: 
pd.set_option('display.max_rows', None)
pd.set_option('display.max_colwidth', 280)
pd.set_option('display.max_colwidth', 280)

with open('Data_set/data/fake_news_on_russian_language.json', encoding='utf-8') as json_file2:
    data2 = json.load(json_file2)
print('\nDone Loading fake_news_on_russian_language.json\n')

#make Fake news column
i = 0
text2 = []
links = []
while(True):
    try:
        if(data2['messages'][i]['text_entities'] == []):
            i+=1
            continue
        elif ('Фейк' or 'фейк') in data2['messages'][i]['text_entities'][0]['text']:
            buffer2 = ''
            link = ''
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
            link += 'https://t.me/warfakes/' + str(data2['messages'][i]['id'])
            links.append(link)
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
        print(element,'   ',translate[element])
except Exception as e:
        print('\n\n',e)

dataframe2 = pd.DataFrame()
dataframe2['Link'] = links
dataframe2['Text'] = translate
dataframe2['Label'] = 'False'        

site_fakes = import_data_from_site()
site_fakes = list(site_fakes)
#translate russian news into ukrainian language
translate = []
try:
    for element in range(len(site_fakes)):
        translate.append((translator.translate(site_fakes[element], src='ru', dest='uk')).text)
        print(element,'   ',translate[element])
except Exception as e:
        print('\n\n',e)

#add another 222 fake examples 
vox_link = ['https://voxukraine.org/category/voks-informue/' for i in range(len(site_fakes))]
dataframe_buff = pd.DataFrame()
dataframe_buff['Link'] = vox_link
dataframe_buff['Text'] = site_fakes
dataframe_buff['Label'] = 'False'

#concatenate 2 fakes
fake_news = pd.concat([dataframe_buff, dataframe2], axis=0)
print('\n\n\n\n')
print(fake_news)

print('\n\n\n\n',"end of russian news")
fake_news.to_csv('Data_set/data/verified_datasets/Russian_fake_news_verified.csv')
