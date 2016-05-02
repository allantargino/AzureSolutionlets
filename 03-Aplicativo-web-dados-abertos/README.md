# #AzureSolutionlet - Dados Abertos

##Wifi Livre em São Paulo
Encontre redes wifi com acesso gratuito na cidade de São Paulo.

> Este web app foi desenvolvido com dados abertos e hospedado na plataforma [Microsoft Azure](https://azure.microsoft.com/pt-br/) e faz parte da série #AzureSolutionlets, onde resolve-se problemas específicos através de rápidos deploys utilizando o Microsoft Azure. Os dados abertos utilizados nesta aplicação, estão disponíveis no portal [Praças Wifi Livre SP](http://wifilivre.sp.gov.br/). 

Através deste Hands-on-lab você aprenderá a criar e configurar de um web app com integração contínua. Os recursos utilizados para deploy deste web app são extremamente úteis em projetos de diversos portes e é interessante que você faça o setup de uma conta trial no Azure a fim de obter o máximo desempenho e poder utilizar os recursos da plataforma.

### Passo 0: Criar conta trial do Microsoft Azure
Acesse https://azure.microsoft.com/pt-br/pricing/free-trial/ e clique no botão **Teste agora**:

![](https://raw.githubusercontent.com/allantargino/AzureSolutionlets/master/01-Prevendo-valores-no-Excel/images/p0-img01.png)

Logue-se com uma conta Microsoft (hotmail, live, etc). Em seguida, preencha seus dados. É necessário um telefone celular para verificar sua identidade, bem como um cartão de crédito válido. Após ler os termos e, caso concorde com eles, cheque *Eu concordo..."* seguido do clique em **Inscrever-se**:

![](https://raw.githubusercontent.com/allantargino/AzureSolutionlets/master/01-Prevendo-valores-no-Excel/images/p0-img02.png)

Você será uma levado a uma página onde deve aguardar alguns instantes até que sua subscrição esteja pronto para uso. Uma vez pronta, clique no botão verde para continuar e ser levado à tela inicial do Microsoft Azure:

![](https://raw.githubusercontent.com/allantargino/AzureSolutionlets/master/01-Prevendo-valores-no-Excel/images/p0-img03.png)

### Passo 1: Executando o projeto
Clone este projeto em sua máquina e instale as dependências via command line:
```
npm install
```
O gerenciamento de tasks do app é feito com [gulp](http://gulpjs.com/). Após a instalação das dependências, execute o comando a seguir:
```
gulp
```
Seu projeto estará acessível em: `127.0.0.1:4000`. Você poderá debbugar e desenvolver novas funcionalidades para este projeto e até criar outras aplicações, baseadas nesta arquitetura.

### Passo 2: Criando um Aplicativo Web no Azure
Para criar um novo aplicativo web, no menu lateral de seu dashboard no Azure, clique em **New** > **Web + Mobile** > **Web App**. Insira informações como nome (o nome do seu aplicativo irá gerar sua URL pública de acesso ao web app), assinatura e resource group. Você poderá criar um resource group durante a configuração de sua web app ou selecionar um [resource group](https://azure.microsoft.com/pt-br/documentation/articles/resource-group-portal/) já existente.

![criando-um-aplicativo-web-no-azure-01](https://cloud.githubusercontent.com/assets/2198735/14955729/606ded68-1052-11e6-9ad4-21a9ea3c8c95.PNG)

Em alguns instantes, sua aplicação estará disponível. Com o web app gerado, você poderá acessá-lo pelo link e irá encontrar a seguinte tela:

![preview-aplicativo-web-no-azure-02](https://cloud.githubusercontent.com/assets/2198735/14955866/306d2a24-1053-11e6-86c8-36ee49fe5e67.PNG)

### Passo 3: Integração com Github
O código-fonte e versionamento do *Wifi Livre SP* está centralizado no Github e para fazer o deploy do projeto no Azure, será necessário configurar uma integração entre o repositório e a aplicação criada na nuvem. Para isso, acessamos os detalhes da aplicação e clicamos no menu **settings**, que abrirá um painel lateral com opções de serviços que podemos utilizar.

![configuracoes-aplicativo-web-no-azure-03](https://cloud.githubusercontent.com/assets/2198735/14960521/6c1c439e-106b-11e6-9c0a-0132f99b02e4.PNG)

No painel lateral, localize a opção **deployment source** e selecione a opção de repositório que sua aplicação está hospedada. Neste caso, utilizaremos o Github.

![deploy-github-no-azure](https://cloud.githubusercontent.com/assets/2198735/14960801/cfee3eee-106c-11e6-892d-b6eee4d3db89.PNG)

Ao selecionar o Github, será necessário vincular sua conta com o Azure. Após autorizar a integração das contas (Github + Azure), irá surgir a lista de repositórios que você possui no Github. Selecione o repositório desejado, defina a branch que será sincronizada com o Azure. CLique no botão **OK** e aguarde alguns instantes.

![deploy-github-no-azure-02](https://cloud.githubusercontent.com/assets/2198735/14961191/ce68ef4a-106e-11e6-868e-2d0a58a6a8e9.PNG)

Feita a integração para o deploy, o Azure fará o primeiro sync da aplicação. A medida em que o repositório receber atualizações, um novo sync é realizado e você poderá acompanhar o histórico de alterações e qual é a versão que está rodando em sua app.

![deploy-github-no-azure-03](https://cloud.githubusercontent.com/assets/2198735/14961009/f4507044-106d-11e6-8215-a04e2b89c246.PNG)

### Arquivos estáticos
O *Wifi Livre SP* é um web app estático e utiliza como fonte de dados um arquivo `.json` para renderizar a listagem de locais com acesso Wifi gratuito e livre na cidade. Para que que a aplicação possa consumir os dados, é necessário adicionar um arquivo `web.config` para liberar acesso ao arquivo `pracas.json`.

```xml
<?xml version="1.0"?>
<configuration>
    <system.webServer>
      <staticContent>
        <mimeMap fileExtension=".json" mimeType="application/json" />
     </staticContent>
    </system.webServer>
</configuration>
```

Com as configurações iniciais concluídas, sua aplicação já está disponível para uso.

![app-01](https://cloud.githubusercontent.com/assets/2198735/14961802/09d2943e-1072-11e6-9c1c-9f8215e858c2.PNG)

Parabéns, você conclui este Hands-on-lab e conseguiu criar uma web app, baseada em dados abertos e com integração contínua.
