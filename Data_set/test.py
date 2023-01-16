# Load library
import pandas as pd
import demoji
import json
from googletrans import Translator

# Environment settings: 
pd.set_option('display.max_rows', None)
pd.set_option('display.max_colwidth', 210)

with open('Data_set\data\Perepichka_NEWS.json', encoding='utf-8') as json_file:
    data = json.load(json_file)
print('\nDone Loading Perepichka_NEWS.json\n')
i = 0
k = 0
text = []
false_words = ['СБУ' , 'Фото' ,'фото' , 'відео', 'Відео']
link = ''
buffer = ''
while(i!=3000):
    try:
        buffer = ''
        if(data['messages'][i]['text'] == ''):
                i+=1
                continue
        elif('bold' in str(data['messages'][i])):
            for k in range(len(data['messages'][i]['text_entities'])):
                if data['messages'][i]['text_entities'][k]['type'] == 'bold':
                    buffer += (data['messages'][i]['text_entities'][k]['text']).replace('\n' or '\\' or '�', ' ')
            buffer = demoji.replace(buffer, "")
            print(buffer[0],'\t',buffer)
            if (len(buffer) > 200):
                i+=1
                continue
            if len(buffer) > 40:
                if buffer[0] != ('«' or '"') :
                    buffer_into_words = buffer.split(' ')
                    if not any(value for value in false_words if value in buffer_into_words):
                        if ':' not in buffer:
                            text.append(demoji.replace(buffer, ""))      
        i+=1
    except:
        print(text)
print(text)


#print(len(''))
