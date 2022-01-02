# ADO.NET

## Interfaces e Classes System.Data:

![alt text](images/interfaces.png?raw=true=250x250 "Title")

![alt text](images/interface-classebase-classeconcreta.png?raw=true=250x250 "Title")



## IDbConnection:

Representa uma conexão aberta com uma fonte de dados e é implementado pelo .NET Framework.  

Ela contém as informações necessárias para se conectar ao banco de dados: string de conexão, estado da conexão, etc.



## IDbCommand:

Representa uma instrução SQL a ser executada enquanto conectada a uma fonte de dados. Além de informações do comando a ser executado (texto do comando, tipo de comando, etc), faz referência a uma determinada conexão de banco de dados (`IDbConnection`) e a uma transação (`IDbTransaction`) se houver.

Temos basicamente três formas de executar comandos e retornar dados:

1. **dbCommand.ExecuteNonQuery()**;
    Para inserir, atualizar e/ou excluir registros em um banco de dados. Retorna um valor `inteiro` com a quantidade de linhas afetadas.

2. **dbCommand.ExecuteScalar()**;
    SQL SELECT para retornar apenas um valor do banco de dados.

3. **dbCommand.ExecuteReader()**:
    SQL SELECT para retornar um conjunto de dados para visualização.


Quando iniciada uma transação (`IDbConnection.BeginTransaction()`), podemos invocar os métodos `Commit()` e `Rollback()`. Vejamos mais sobre transaçoes no tópico a seguir.



## IDbTransaction:

Representa uma transação a ser realizada em uma fonte de dados. Faz referência a uma determinada conexão de banco de dados (`IDbConnection`).

Se uma transação for iniciada (`DbConnection.BeginTransaction()`), um comando SQL (insert, update, delete) só será efetivado ao se executar um commit (`DbTransaction.Commit()`). 

Usamos transações quando desejamos garantir que toda uma operação (sequencia de comandos) sejam executados. Sendo assim, podemos também cancelar (`DbTransaction.Rollback()`) todos os comandos executados até então.

Obs: Se um comando SQL (insert, update, delete) for executado SEM INICIAR uma transação, ele será imediatamente efetivado no banco de dados.


## Referencias

<https://viniciusrtavares.wordpress.com/2014/05/18/design-pattern-unit-of-work/>
<http://www.macoratti.net/12/04/c_dbind.htm>
<http://www.macoratti.net/09/05/c_adn_4.htm>