import pandas as pd
import os
import glob

# Environment settings: 
pd.set_option('display.max_rows', None)
pd.set_option('display.max_colwidth', 140)

glued_data = pd.DataFrame()
for file_name in glob.glob('Data_set/data/csv_files/*'):
    x = pd.read_csv(file_name, low_memory=False)
    glued_data = pd.concat([glued_data,x],axis=0)
# print(glued_data)
glued_data.info()
columns_train = ['Text','Label']
dataset_2 = glued_data[columns_train]

print(dataset_2)
dataset_2.to_csv('Data_set/data/data_set_2.csv')