# #AzureSolutionlet - Prevendo valores no Excel
Através deste Hands-on-lab você aprenderá a fazer a previsão de valores no Excel utilizando técnicas de regressão linear dentro do Azure Machine Learning Studio. É interessante que você faça o setup de uma conta trial no Azure a fim de obter o máximo desempenho e recursos do ML Studio, apesar disto não ser necessário para utilizá-lo.
>Ao criar sua conta trial, você receberá R$ 750,00 para gastar em todos serviços do Azure, como máquinas virtuais, bancos de dados SQL, sites e muitos outros.

### Passo 0: Conta Trial do Azure
>Caso você já possua uma subscrição ativa do Azure, por favor pule esta etapa.

Acesse https://azure.microsoft.com/pt-br/pricing/free-trial/ e clique no botão **Teste agora**:
![Oferta Trial do Azure](https://github.com/allantargino/AzureSolutionlets/blob/master/01-Prevendo-valores-no-Excel/images/p0-img01.png)

Logue-se com uma conta Microsoft (hotmail, live, etc). Em seguida, preencha seus dados. É necessário um telefone celular para verificar sua identidade, bem como um cartão de crédito válido. Após ler os termos e, caso concorde com eles, cheque *Eu concordo..."* seguido do clique em **Inscrever-se**:
![Cadastro](https://github.com/allantargino/AzureSolutionlets/blob/master/01-Prevendo-valores-no-Excel/images/p0-img02.png)

Você será uma levado a uma página onde deve aguardar alguns instantes até que sua subscrição esteja pronto para uso. Uma vez pronta, clique no botão verde para continuar e ser levado à tela inicial do Microsoft Azure:
![Tela Inicial](https://github.com/allantargino/AzureSolutionlets/blob/master/01-Prevendo-valores-no-Excel/images/p0-img03.png)

### Passo 1: Regressão Linear Simples com Azure
Dentro do portal do Azure, clique em **New**, seguido de **Data + Analytics** e **Machine Learning**, conforme a figura abaixo:
![Criação ML](https://github.com/allantargino/AzureSolutionlets/blob/master/01-Prevendo-valores-no-Excel/images/p1-img01.png)

Você será levado ao portal antigo do Azure, onde deve dar um nome para o Workspace, bem como para uma conta de armazenamento:
![Criação WS](https://github.com/allantargino/AzureSolutionlets/blob/master/01-Prevendo-valores-no-Excel/images/p1-img02.png)

Após alguns instantes, o Workspace será criado e aparecerá na aba Machine Learning. Clique em *ExperimentosExcel*:
![WS Criado](https://github.com/allantargino/AzureSolutionlets/blob/master/01-Prevendo-valores-no-Excel/images/p1-img03.png)

Em seguida, clique em *Sign-in to ML Studio*:
![ML Studio](https://github.com/allantargino/AzureSolutionlets/blob/master/01-Prevendo-valores-no-Excel/images/p1-img04.png)
>Você pode chegar ao mesmo ambiente acessando diretamente o endereço https://studio.azureml.net. Caso você não tenha uma subscrição do Azure, pode acessar o ambiente (de maneira limitada) logando-se com uma conta Microsoft.

Ao chegar entrar no ambiente do ML Studio, clique em **New**, **Dataset**, seguido de **From local file**:
![Upar DS](https://github.com/allantargino/AzureSolutionlets/blob/master/01-Prevendo-valores-no-Excel/images/p1-img05.png)

Pegue, neste repositório, o arquivo *apartamentos.csv* e use o formulário aberto para inseri-lo ML Studio, conforme abaixo:
![Upar DS](https://github.com/allantargino/AzureSolutionlets/blob/master/01-Prevendo-valores-no-Excel/images/p1-img06.png)

Após obter a confirmação que o arquivo foi submetido, clique em **New**, **Experiment**, seguido de **Blank Experiment**:
![Novo Exp](https://github.com/allantargino/AzureSolutionlets/blob/master/01-Prevendo-valores-no-Excel/images/p1-img07.png)

Renomeie o nome do experimento para **Apartamentos Exp**:
![Renomear](https://github.com/allantargino/AzureSolutionlets/blob/master/01-Prevendo-valores-no-Excel/images/p1-img08.png)

### Passo 2: Consumindo o serviço anterior web de ML dentro do Excel
Uma vez realizado o passo anterior, podemos utilizar o Excel como interface para prever quaisquer valores de entrada neste mesmo schema.
Abra o arquivo **Apartamentos_Relatorio.xlsx** e certifique-se que está na planilha *Apartamentos - Multipla*. Vá na aba Insert (Inserir), clicando no botão Store (Suplementos):
>Caso não tenha o Microsoft Excel em sua máquina, logue-se em https://office.live.com/start/Excel.aspx e reproduza os mesmos passos a seguir.

 ![Add App](https://github.com/allantargino/AzureSolutionlets/blob/master/01-Prevendo-valores-no-Excel/images/p2-img01.png)
 
 Pesquise por *Machine Learning* pressionando enter, cliquando no resultado da figura mostrada abaixo:
![Add App](https://github.com/allantargino/AzureSolutionlets/blob/master/01-Prevendo-valores-no-Excel/images/p2-img02.png)

Clique em **Trust** para adicionar o Excel Add-in a sua solução:
![Add App](https://github.com/allantargino/AzureSolutionlets/blob/master/01-Prevendo-valores-no-Excel/images/p2-img03.png)


![Renomear](https://github.com/allantargino/AzureSolutionlets/blob/master/01-Prevendo-valores-no-Excel/images/p2-img04.png)
![Renomear](https://github.com/allantargino/AzureSolutionlets/blob/master/01-Prevendo-valores-no-Excel/images/p2-img05.png)
![Renomear](https://github.com/allantargino/AzureSolutionlets/blob/master/01-Prevendo-valores-no-Excel/images/p2-img06.png)
![Renomear](https://github.com/allantargino/AzureSolutionlets/blob/master/01-Prevendo-valores-no-Excel/images/p2-img07.png)
![Renomear](https://github.com/allantargino/AzureSolutionlets/blob/master/01-Prevendo-valores-no-Excel/images/p2-img08.png)
![Renomear](https://github.com/allantargino/AzureSolutionlets/blob/master/01-Prevendo-valores-no-Excel/images/p2-img09.png)
![Renomear](https://github.com/allantargino/AzureSolutionlets/blob/master/01-Prevendo-valores-no-Excel/images/p2-img10.png)