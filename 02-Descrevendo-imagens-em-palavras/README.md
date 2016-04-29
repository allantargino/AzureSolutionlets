# #AzureSolutionlet - Analisando imagens

>Este Hands-On Labs faz parte da série #AzureSolutionlets, onde resolveremos problemas específicos através de rápidos deploys utilizando o [Microsoft Azure](https://azure.microsoft.com/pt-br/). O vídeo relacionado a esta solução pode ser encontrado [aqui](#).

Através deste Hands-On Labs você aprenderá a utilizar as [APIs de Visão Computacional](https://www.microsoft.com/cognitive-services/en-us/computer-vision-api) para extrair informações de imagens. Essas APIs fazem parte do pacote de [Serviços Cognitivos da Microsoft](https://www.microsoft.com/cognitive-services) que permite que os desenvolvedores adicionem facilmente recursos poderosos e inteligentes em suas aplicações.

Para demonstrar esses conceitos, utilizaremos uma aplicação Web, hospedada no Microsoft Azure, que pode se conectar ao serviço de imagens Flickr para poder categorizar fotos, facilitando assim sua busca.

Para poder reproduzir os passos que descreveremos aqui, você precisará de uma conta trial no Azure. Ao criar sua conta trial, você receberá R$ 750,00 para gastar em todos serviços do Azure, como máquinas virtuais, bancos de dados SQL, sites e muitos outros. Caso você já possua uma subscrição ativa do Azure, por favor pule o Passo 0.

### Passo 0: Criar conta trial do Microsoft Azure
Acesse [https://azure.microsoft.com/pt-br/pricing/free-trial](https://azure.microsoft.com/pt-br/pricing/free-trial) e clique no botão **Teste agora**:

![](/ImageTagging/images/azure-solutionlets-image-tagging-01.png)

Logue-se com uma conta Microsoft (hotmail, live, etc). Em seguida, preencha seus dados. É necessário um telefone celular para verificar sua identidade, bem como um cartão de crédito válido. Após ler os termos e, caso concorde com eles, cheque *Eu concordo..."* seguido do clique em **Inscrever-se**:

![](/ImageTagging/images/azure-solutionlets-image-tagging-02.png)

Você será uma levado a uma página onde deve aguardar alguns instantes até que sua subscrição esteja pronto para uso. Uma vez pronta, clique no botão verde para continuar e ser levado à tela inicial do Microsoft Azure:

![](/ImageTagging/images/azure-solutionlets-image-tagging-03.png)

### Passo 1: Criar chave do Microsoft Cognitive Services
Acesse [https://www.microsoft.com/cognitive-services/en-us/subscriptions](https://www.microsoft.com/cognitive-services/en-us/subscriptions) e clique no botão **Request new trials**:

![](/ImageTagging/images/azure-solutionlets-image-tagging-04.png)

Selecione o item **Computer Vision - Preview**, aceite os termos de uso e clique no botão **Subscribe**:

![](/ImageTagging/images/azure-solutionlets-image-tagging-05.png)

Encontre na lista a API **Computer Vision - Preview** e clique no botão **show** para mostrar a chave da sua API:

![](/ImageTagging/images/azure-solutionlets-image-tagging-06.png)

Guarde essa chave.

### Passo 2: Criar chave do Flickr
Acesse [https://www.flickr.com/services/api/misc.api_keys.html](https://www.flickr.com/services/api/misc.api_keys.html) e clique no link **Apply for your key online now**:

![](/ImageTagging/images/azure-solutionlets-image-tagging-07.png)

Escolha o tipo do seu aplicativo: Não comercial ou comercial:

![](/ImageTagging/images/azure-solutionlets-image-tagging-08.png)

Entre com as informações do seu app e clique no botão **SUBMIT**:

![](/ImageTagging/images/azure-solutionlets-image-tagging-09.png)

Guarde as chaves geradas:

![](/ImageTagging/images/azure-solutionlets-image-tagging-10.png)

### Passo 3: Adicionar as chaves no projeto
Clone esse repositório e abra a solução do projeto no visual Studio (**ImageTagging.sln**)

Abra o arquivo de configuração **Web.config** e altere os esses campos, onde:

**[YOUR_MICRSOFT_COGNITIVE_KEY]** => Chave do Microsoft Cognitive Services

**[YOUR_FLIKR_API_KEY]** => Chave do Flickr

**[YOUR_FLIKR_SHARED_SECRET_KEY]** => Shared Secret do Flickr


    <appSettings>
      <add key="CognitiveServiceSubscriptionKey" value="[YOUR_MICRSOFT_COGNITIVE_KEY]"/>
      <add key="FlickrApiKey" value="[YOUR_FLIKR_API_KEY]"/>
      <add key="FlickrSharedSecret" value="[YOUR_FLIKR_SHARED_SECRET_KEY]"/>
      .
      .
      .
    </appSettings>

### Passo 4: Publicar o projeto no Microsoft Azure

No Visual Studio, clique com o botão direito no projeto **ImageTagging** e selecione o item **Publish...**:

![](/ImageTagging/images/azure-solutionlets-image-tagging-11.png)

Selecione a opção **Microsoft Azure Web Apps**:

![](/ImageTagging/images/azure-solutionlets-image-tagging-12.png)

Escolha a sua assinatura e clique no botão **New...**:

![](/ImageTagging/images/azure-solutionlets-image-tagging-13.png)

Adicione um **Web App Name** único, selecione ou crie um novo **App Service Plan** e clique no botão **Create**:

![](/ImageTagging/images/azure-solutionlets-image-tagging-14.png)

Ao finalizar a criação do **Web App** vamos publicar o projeto no **Azure** clicando no botão **Publish**:

![](/ImageTagging/images/azure-solutionlets-image-tagging-15.png)

O projeto será compilado e publicado no **Microsoft Azure**:

![](/ImageTagging/images/azure-solutionlets-image-tagging-16.png)

Parabéns! Você concluiu este Hands-on-lab e conseguiu obter as palavras correspondentes as imagens!

### Recursos Adicionais

* [MVA de Azure](https://mva.microsoft.com/product-training/microsoft-azure)
* [Channel 9 Cognitive Services](https://channel9.msdn.com/Events/Build/2016/B878)
* [talkitbr](https://talkitbr.com/)
