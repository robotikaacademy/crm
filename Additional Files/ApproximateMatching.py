from fuzzywuzzy import process
import sys

with open('D:\Programs\Solutions\My Projects\crm\Additional Files\\names.txt') as f:
    names = f.read().split('\n')

def get_matches(query, choices, limit=3):
    results = process.extract(query, choices, limit=limit)
    print(results)

get_matches(sys.argv[1], names)