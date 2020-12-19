--1. Com base no modelo acima, escreva um comando SQL que liste a quantidade de processos por Status com sua descrição.

SELECT  COUNT(p.IdStatus) AS QTD_PROCESSOS, s.dsStatus as DS_STATUS from tb_Processo p 
INNER JOIN tb_Status s ON p.IdStatus = s.idStatus
GROUP BY p.IdStatus, s.dsStatus ORDER BY p.IdStatus, s.dsStatus


--2. Com base no modelo acima, construa um comando SQL que liste a maior data de andamento por número de processo, com processos encerrados no ano de 2013.

SELECT P.nroProcesso AS NR_PROCESSO, MAX(A.dtAndamento) AS MAIOR_DT_LANCAMENTO FROM tb_Andamento A 
INNER JOIN tb_Processo P ON
A.idProcesso = P.idProcesso
WHERE YEAR(P.DtEncerramento) = 2013
GROUP BY P.nroProcesso, A.dtAndamento
ORDER BY P.nroProcesso, A.dtAndamento


--3. Com base no modelo acima, construa um comando SQL que liste a quantidade de Data de Encerramento agrupada por ela mesma onde a quantidade da contagem seja maior que 5.

SELECT COUNT(P.DtEncerramento) AS QTD_ENCERRAMENTO , P.DtEncerramento AS DT_ENCERRAMENTO FROM tb_Processo P
GROUP BY P.DtEncerramento
HAVING COUNT(P.DtEncerramento) > 5


--4. Possuímos um número de identificação do processo, onde o mesmo contém 12 caracteres com zero à esquerda, 
--contudo nosso modelo e dados ele é apresentado como bigint. Como fazer para apresenta-lo com 12 caracteres considerando os zeros a esquerda?

SELECT REPLICATE('0', 12 - LEN(nroProcesso)) + RTrim(nroProcesso) AS NR_PROCESSO FROM tb_Processo
