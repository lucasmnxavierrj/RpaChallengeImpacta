# Desafio RPA Impacta

O objetivo desta solução é coletar dados de proxies de um site e armazená-los em um banco de dados via uma API. Ele é dividido em 4 projetos principais:

1. **Crawler**: Responsável por buscar e processar os dados dos proxies.
2. **API**: Responsável por receber e armazenar os dados dos proxies no banco de dados.
3. **Domain**: Biblioteca de classes responsável por armazenar as entidades e enumeradores de domínio.
4. **DataAccess**: Responsável por conter o contexto do banco, as migrações e os mapeamentos de tabela.

### Executando o Projeto
1. Certifique-se de que você tenha um banco de dados SQL Server configurado e atualizado com a string de conexão no `appsettings.json` da API.
2. Rode primeiro a API, após a porta ter sido exposta, copie ela e cole na url presente no arquivo **SaveProxyDataIntoDatabase.cs**.
3. Execute o Crawler.

### Observação
Todo o código e mensagens de retorno foram escritos em inglês, tendo em vista que os dados de domínio eram em inglês.
