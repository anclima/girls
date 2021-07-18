# -*- coding: utf-8 -*-
"""
Created on Sat Jul 17 15:11:50 2021
@author: Alexandre Sucupira
@name: FHIR.Broker
@description: Conversor de formatos de dados de saúde oriundos de registros
eletrônicos de saúde, em qualquer formato base, para o padrão H7 FHIR 4.0.
"""
###############
# Bibliotecas #
###############

# import requests as req # Realizar chamadas HTTP(S)
# Framework WSGI
from bottle import get, post, request, run, static_file as sf
from json import loads, dumps # Tratar JSON
# from os import curdir as pwd # recebe o diretório
# import re # Expresões regulares


#################
# Configurações #
#################

# Config do servidor da API

config = {'host': 'localhost',
          'port': 8080,
          'debug': True,
          'server': 'waitress'}

###########
# Funções #
###########

# Função principal. Converte enrtada qualquer em H7 FHIR 4.
def anyToFHIR(source, data):
  # TODO: Definir os métodos de conversão, bibliotecas etc.
  pass


#######
# API #
#######

# Rotas GET
## Documentação

@get('/')
def docs():
  # ret = {'nome': nome}
  # return dumps(ret)
  return sf('doc.html', root='.')


# Rotas POST
## Entrada de Dados
# Recebe via POST um JSON contendo dados de paciente em qualquer formato,
# faz a conversão dos mesmos para o padrão H7 FHIR 4 e encaminha para o
# próximo módulo (fhir.girls), também via JSON, opcionalmente retornando o
# resultado do processamento para o requisitante.

@post('/input')
def fhir_broker():
  asd = loads(request.form.get('data'))
  return asd

# run(host='localhost', port=8080, debug=True, server='waitress')
# Executa o servidor com a configuração feita anteriormente.
run(**config)