# ADO.NET

![alt text](images/interfaces.png?raw=true=250x250 "Title")

![alt text](images/interface-classebase-classeconcreta.png?raw=true=250x250 "Title")


`IDbConnection` é uma interface que tem uma propriedade `BeginTransaction` que retorna um `IDbTransaction`, que por sua vez possui os métodos `Commit()` e `Rollback()`.

`IDbCommand`é a interface que provê a execução de comandos SQL junto ao banco de dados. Temos basicamente três formas de executar comandos e retornar dados:

1. dbCommand.ExecuteNonQuery();
    Para inserir, atualizar e/ou excluir registros em um banco de dados. Retorna um valor `inteiro` com a quantidade de linhas afetadas.

2. dbCommand.ExecuteScalar();
    SQL SELECT para retornar apenas um valor do banco de dados.

3. dbCommand.ExecuteReader():
    SQL SELECT para retornar um conjunto de dados para visualização.


## Referencias

<https://viniciusrtavares.wordpress.com/2014/05/18/design-pattern-unit-of-work/>
<http://www.macoratti.net/12/04/c_dbind.htm>
<http://www.macoratti.net/09/05/c_adn_4.htm>