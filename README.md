# Projeto-Excel

Após baixar o projeto, seguir os seguintes passos:
</br></br>
1- Clicar com botão direito em cima da solution do projeto
</br></br>
2- Selecionar "Properties"
</br></br>
3- Selecionar aba "Startup Projects" e escolher a opção "Multiple startup projects". Realizar as configurações, conforme imagem abaixo e clicar em "Aplicar"
</br></br>
![alt text](https://github.com/kaiti1987/Excel/blob/master/startup_project.jpg?raw=true)
</br></br>
4- Clicar com botão direito em cima da solution do projeto, clicar em "Clean Solution" e depois "Rebuild Solution"
</br></br>
5- Apertar "F5" para testar o projeto.
</br></br>
6- Gerar massa de dados e aguardar a mensagem de finalização "Massa de dados gerado com sucesso!"
![alt text](https://github.com/kaiti1987/Excel/blob/master/MassaDados.jpg?raw=true)
</br></br>
7- Selecionar o "Tipo de Visualização" e clicar em "Pesquisar"
![alt text](https://github.com/kaiti1987/Excel/blob/master/Pesquisar.jpg?raw=true)
</br></br>
8- Aparecerá as opções para exportar nos seguintes formatos "Excel" e "CSV"
![alt text](https://github.com/kaiti1987/Excel/blob/master/Export.jpg?raw=true)
</br></br>
9- Após selecionar o formato, o arquivo será aberto automaticamente em seu computador
</br></br>
</br></br>
Considerações no desenvolvimento:
</br></br>
a) Foi utilizado o pacote NPOI para geração de arquivos Excel, por ser gratuito e não precisar instalar recusros do pacote Office (Interop).
</br></br>
b) Como foi um pré requisito o desenvolvimento de uma app desktop, foi utilizado Windows Form, devido a facilidade e a performance melhor em relação ao WPF.
</br></br>
c) Para log foi utilizado o Serilog. Os logs são gravados em arquivo (diretório "Logs" na raiz do projeto). 

