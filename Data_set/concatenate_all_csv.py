import pandas as pd
import os
import glob

# Environment settings: 
pd.set_option('display.max_rows', None)
pd.set_option('display.max_colwidth', 250)
pd.set_option('display.max_colwidth', 250)

glued_data = pd.DataFrame()
for file_name in glob.glob('Data_set/data/verified_datasets/*'):
    x = pd.read_csv(file_name, low_memory=False)
    glued_data = pd.concat([glued_data,x],axis=0)
# print(glued_data)
glued_data.info()
columns_train = ['Link','Text','Label']
dataset_4 = glued_data[columns_train]

print(dataset_4)
dataset_4.to_csv('Data_set/data/data_set_4.csv')