# #AzureSolutionlet - Prevendo valores no Excel

>Este Hands-on-lab faz parte da série #AzureSolutionlets, onde resolve-se problemas específicos através de rápidos deploys utilizando o Microsoft Azure. O vídeo relacionado a esta solução pode ser encontrado [aqui](#).

Através deste Hands-on-lab você aprenderá a fazer a previsão de valores no Excel utilizando técnicas de regressão linear dentro do Azure Machine Learning Studio. É interessante que você faça o setup de uma conta trial no Azure a fim de obter o máximo desempenho e recursos do ML Studio, apesar disto não ser necessário para utilizá-lo.
>Ao criar sua conta trial, você receberá R$ 750,00 para gastar em todos serviços do Azure, como máquinas virtuais, bancos de dados SQL, sites e muitos outros. Caso você já possua uma subscrição ativa do Azure, por favor pule o Passo 0.

### Passo 0: Conta Trial do Azure
Acesse https://azure.microsoft.com/pt-br/pricing/free-trial/ e clique no botão **Teste agora**:
![](/01-Prevendo-valores-no-Excel/images/p0-img01.png)

Logue-se com uma conta Microsoft (hotmail, live, etc). Em seguida, preencha seus dados. É necessário um telefone celular para verificar sua identidade, bem como um cartão de crédito válido. Após ler os termos e, caso concorde com eles, cheque *Eu concordo..."* seguido do clique em **Inscrever-se**:
![](/01-Prevendo-valores-no-Excel/images/p0-img02.png)

Você será uma levado a uma página onde deve aguardar alguns instantes até que sua subscrição esteja pronto para uso. Uma vez pronta, clique no botão verde para continuar e ser levado à tela inicial do Microsoft Azure:
![](/01-Prevendo-valores-no-Excel/images/p0-img03.png)

### Passo 1: Regressão Linear Simples com Azure
Dentro do portal do Azure, clique em **New**, seguido de **Data + Analytics** e **Machine Learning**, conforme a figura abaixo:
![](/01-Prevendo-valores-no-Excel/images/p1-img01.png)

Você será levado ao portal antigo do Azure, onde deve dar um nome para o Workspace, bem como para uma conta de armazenamento:
![](/01-Prevendo-valores-no-Excel/images/p1-img02.png)

Após alguns instantes, o Workspace será criado e aparecerá na aba Machine Learning. Clique em *ExperimentosExcel*:
![](/01-Prevendo-valores-no-Excel/images/p1-img03.png)

Em seguida, clique em *Sign-in to ML Studio*:
![](/01-Prevendo-valores-no-Excel/images/p1-img04.png)
>Você pode chegar ao mesmo ambiente acessando diretamente o endereço https://studio.azureml.net. Caso você não tenha uma subscrição do Azure, pode acessar o ambiente (de maneira limitada) logando-se com uma conta Microsoft.

Ao chegar entrar no ambiente do ML Studio, clique em **New**, **Dataset**, seguido de **From local file**:
![](/01-Prevendo-valores-no-Excel/images/p1-img05.png)

Pegue, neste repositório, o arquivo *apartamentos.csv* e use o formulário aberto para inseri-lo ML Studio, conforme abaixo:
![](/01-Prevendo-valores-no-Excel/images/p1-img06.png)

Após obter a confirmação que o arquivo foi submetido, clique em **New**, **Experiment**, seguido de **Blank Experiment**:
![](/01-Prevendo-valores-no-Excel/images/p1-img07.png)

Renomeie o nome do experimento para **Apartamentos Exp**:
![](/01-Prevendo-valores-no-Excel/images/p1-img08.png)

No menu lateral esquerdo, expanda o nó **Saved Datasets**, em seguida o nó **My Datasets** e arraste o dataset *apartamentos.csv* para o experimento:
![](/01-Prevendo-valores-no-Excel/images/p1-img09.png)

Vá ao nó **Data Transformation**, **Sample and Split** e arraste o bloco **Split Data** ao experimento:
![](/01-Prevendo-valores-no-Excel/images/p1-img10.png)

Clique sobre o bloco **Split Data** adicionado. A janela de propriedades ao lado direita da tela conterá os parâmetros associados a ele, de modo que você deve setar a propriedade **Fraction of rows in the first...** para **0.6**. **Ligue** a saída do dataset a entrada do Split Data.
>O bloco Split Data recebe os dados de um dataset e o divide de maneira aleatória em duas saídas. Em nosso caso, na primeira saída teremos 60% de linhas, ao passo que na segunda saída 40%. Essa divisão é importante pois parte dos dados é realizada a regressão e a outra parte será usada para testes sobre o modelo utilizado. Nossa base de dados é extremamente pequena para fins de Machine Learning, mas como o propósito deste hands-on-lab é apenas guiá-lo nos passos necessários, este detalhe será relevado.

![](/01-Prevendo-valores-no-Excel/images/p1-img11.png)

Agora vá até **Machine Learning**, expanda **Train** e arraste o bloco **Train Model**:
![](/01-Prevendo-valores-no-Excel/images/p1-img12.png)

Pegue também, sobre a categoria **Machine Learning** seguido dos nós **Initialize Model** e **Regression**, o bloco **Linear Regression:
![](/01-Prevendo-valores-no-Excel/images/p1-img13.png)

**Ligue** Linear Regression na **primeira** entrada de Train Model, bem como Split Data na **segunda** entrada. Clique sobre Train Model para que as propriedades do mesmo sejam mostradas no menu lateral direito. Clique em **Launch Column Selector**:
![](/01-Prevendo-valores-no-Excel/images/p1-img14.png)

Nesta etapa devemos selecionar qual valor deverá ser o previsto. Em nosso caso, digite **preco_alguel**, referente ao nosso dataset de apartamentos. Confirme em seguida a seleção:
![](/01-Prevendo-valores-no-Excel/images/p1-img15.png)

Usando o modelo já treinado iremos usar a outra porção inicial dos dados para verificar o quão apurado ele está, computando os valores previstos e comparando-os com os valores reais. Para isto dentro de **Score**, arraste o bloco **Score Model**:
![](/01-Prevendo-valores-no-Excel/images/p1-img16.png)

**Ligue** a saída de **Train Model** à **primeira entrada** de Score Model, bem como a **segunda saída** de Split Data à **segunda entrada** de Score Model: 
![](/01-Prevendo-valores-no-Excel/images/p1-img17.png)

Nosso experimento inicial está pronto. Salve-o clicando em **SAVE** e em seguida clique em **RUN** para rodá-lo, usando o menu inferior.
![](/01-Prevendo-valores-no-Excel/images/p1-img18.png)

Caso não haja erros, um indicador verde de sucesso aparecerá ao lado de cada bloco de execução, conforme mostra a figura abaixo:
![](/01-Prevendo-valores-no-Excel/images/p1-img19.png)

É interessante comparar, mesmo que forma levemente analítica, como nosso modelo se comportou. **Clique com o direito** sobre a **saída** do bloco **Score Model**, e escolha Visualize:
>O mais recomendado é que se utilize a categoria **Evaluate** para obter dados estatísticos sobre como a predição se comportou, como médias, dispersões e outros mais.

![](/01-Prevendo-valores-no-Excel/images/p1-img20.png)

Pode-se notar que alguns valores foram previstos dentro de uma exatidão muito boa (verde), ao passo que alguns outros mantiveram-se um pouco distantes do esperado (amarelo). Tivemos apenas uma anomalia não-tolerável em nosso modelo (vermelho).
![](/01-Prevendo-valores-no-Excel/images/p1-img21.png)

Supondo que nosso modelo de dados atingiu a exatidão desejada, é hora de exportá-lo como um serviço web que pode ser consumido via REST por práticamente qualquer dispositivo/linguagem de programação. No entanto, iremos utilizar o Excel (próxima sessão/passo) para tal. No menu inferior, clique em **SET UP WEB SERVICE**, seguido de **Predictive Web Service**:
![](/01-Prevendo-valores-no-Excel/images/p1-img22.png)

De maneira totalmente automatizada, o Azure irá criar um novo experimento preditivo que tem como base nosso experimento *Apartamentos 01*. O resultado final mostra basicamente que virão dados em JSON através da internet por um serviço HTTP web, que são calculados usando o modelo treinado. O resultado da computação é devolvido também como um resultado JSON HTTP:
![](/01-Prevendo-valores-no-Excel/images/p1-img23.png)

Uma vez que o dataset colocado na mesma porta de **Web service input** define o schema (qual tipo de informação) será inserida no Score Model e, nosso dataset *apartamentos.csv* contém também a coluna *preco_aluguel*, não queremos que esta seja parte da entrada de nosso serviço, de maneira que devemos filtrá-la. Por consequência, teremos um comportamento parecido na saída.
Para melhoramos nosso serviço, iremos filtrar algumas colunas. Para tal, **delete as ligações** entre **apartamentos.csv** e **Score Model**, além de **Score Model** e **Web service output**:
![](/01-Prevendo-valores-no-Excel/images/p1-img24.png)

Realizaremos a seleção/filtragem de colunas usando o bloco **Project Columns**. Ache-o em **Data Transformation** seguido de **Manipulation**, arraste-o para o experimento:
![](/01-Prevendo-valores-no-Excel/images/p1-img25.png)

**Ligue** apartamentos.csv a Project Columns, seguido da ligação de Project Columns a Score Model. **Clique** sobre **Project Columns** e em seguida, dentro da janela de propriedades, clique em **Launch column selector**:
![](/01-Prevendo-valores-no-Excel/images/p1-img26.png)

Usando a seta que aponta para a direita, **selecione todas as colunas com exceção de preco_aluguel**. Confirme a seleção em seguida:
![](/01-Prevendo-valores-no-Excel/images/p1-img27.png)

Arraste outro bloco de **Project Columns** e coloque-o **entre Score Model e Web service output**. Faça as ligações conforme mostra a figura abaixo, ligando Score Model a Project Columns e Project Columns a Web service output. Da mesma forma que feito anteriormente, **clique** no recém-adicionado bloco Project Columns e vá em **Launch column selector**:
![](/01-Prevendo-valores-no-Excel/images/p1-img28.png)

Selecione **apenas** a coluna **Scored Labels**, que é justamente a coluna com os valores previstos/calculados por nosso modelo. Confirme a seleção:
![](/01-Prevendo-valores-no-Excel/images/p1-img29.png)

Usando o menu inferior, salve o experimento preditivo com o botão **SAVE**. Em seguida, rode o experimento utilizando o botão **RUN**. Por fim, clique em **DEPLOY WEB SERVICE** para exportar e fazer deploy do serviço web relativo a nosso modelo de predição:
![](/01-Prevendo-valores-no-Excel/images/p1-img30.png)

Nosso serviço pretivo está pronto! Para prosseguirmos e conseguirmos utilizá-lo em conjunto com o Excel (ou qualquer outro meio), é necessário que se tenha em mãos os dados API key e URL do endpoint do serviço. Clique no **botão copiar** do campo **API key** e guarde este valor em algum lugar, como por exemplo, o bloco de notas.
![](/01-Prevendo-valores-no-Excel/images/p1-img31.png)

Para obter a **URL** de nosso serviço, clique com o direito sobre o link **REQUEST/RESPONSE** e copie o endereço do mesmo. Guarde este valor.
![](/01-Prevendo-valores-no-Excel/images/p1-img32.png)

### Passo 2: Consumindo o serviço anterior web de ML dentro do Excel
Uma vez realizado o passo anterior, podemos utilizar o Excel como interface para prever quaisquer valores de entrada neste mesmo schema.
Abra o arquivo **Apartamentos_Relatorio.xlsx** e certifique-se que está na planilha *Apartamentos - Multipla*. Vá na aba Insert (Inserir), clicando no botão Store (Suplementos):
>Caso não tenha o Microsoft Excel em sua máquina, logue-se em https://office.live.com/start/Excel.aspx e reproduza os mesmos passos a seguir.

![](/01-Prevendo-valores-no-Excel/images/p2-img01.png)
 
 Pesquise por *Machine Learning* pressionando enter, cliquando no resultado da figura mostrada abaixo:
![](/01-Prevendo-valores-no-Excel/images/p2-img02.png)

Clique em **Trust it** para adicionar o Excel Add-in a sua solução:
![](/01-Prevendo-valores-no-Excel/images/p2-img03.png)

Após o add-in ser adicionado ao Excel, clique em **Add Web Service**:
![](/01-Prevendo-valores-no-Excel/images/p2-img04.png)

Neste momento você irá utilizar os valores da **URL** e **API Key**, colando-os nos respectivos campos. Em seguida clique em **Add**:
![](/01-Prevendo-valores-no-Excel/images/p2-img05.png)

Devemos agora indicar ao add-in quais dados desejamos prever. Selecione o intervalo de dados na planilha conforme mostra a figura, clicando no botão do campo *Input1* (em vermelho, abaixo):
![](/01-Prevendo-valores-no-Excel/images/p2-img06.png)

Pressione **Ok**:
![](/01-Prevendo-valores-no-Excel/images/p2-img07.png)

**Desmarque** a caixa **My data has headers**. No campo output1, deve-se colocar a primeira célula que receberá o resultado do processamento dos dados de entrada. Em nosso caso, clique dentro de **output1** e digite **K7**. **Desmarque** também a caixa **Include headers**:
![](/01-Prevendo-valores-no-Excel/images/p2-img08.png)

Após tirar o foco da caixa output1, bem como realizar todos os passos acima, o add-in deve estar semelhante à figura abaixo. Por fim, clique em **Predict**:
![](/01-Prevendo-valores-no-Excel/images/p2-img09.png)

Parabéns! Você concluiu este Hands-on-lab e conseguiu prever valores utilizando o Azure Machine Learning e Excel!
>Neste experimento realizamos um processo simples de Machine Learning. Em um experimento mais completo, deveríamos utilizar recursos mais avançados.

![](/01-Prevendo-valores-no-Excel/images/p2-img10.png)

### Recursos Adicionais:

* [MVA de Machine Learning](https://mva.microsoft.com/en-us/training-courses/data-science-and-machine-learning-essentials-14100?l=UyhoTxWdB_3505050723)
* [GitHub do MVA de Machine Learning](https://github.com/MicrosoftLearning/Data-Science-and-ML-Essentials)
