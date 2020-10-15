## C# - Developer 

Parabéns, você passou para a segunda fase do processo seletivo da MáximaTech para desenvolvedor Fullstack (C# + Angular).

## Instruções

1. Criar um fork deste repositório, transformar ele em privado, adicionar o nosso usuário (talentosmaxima) como colaborador e implementar o aplicativo conforme instruções abaixo.
2. Enviar um e-mail para <talentoshumanos@maximatech.com.br> com:
	* Assunto "[Teste Desenvolvedor C#] - Nome do candidato"
	* Link: -> Repositório privado no Github.

É hora do show!

## Resumo

Você foi escolhido para escrever uma PoC (Prova de Conceito) de um e-commerce, basicamente o sistema consiste na criação de Pedidos (cliente + produtos + frete).

O usuário após logar no sistema selecionará a opção "Novo Pedido" para iniciar a venda. 

## Seguem os requisitos:

* A stack de tecnologia a ser utilizada é C# .NET Core + Angular 6 ou Superior.
* O sistema é composto por 3 microserviços: Serviço Web (Angular) + API Backend (.NET Core) + Serviço de Cálculo de Frete (.NET Core).
* Banco de dados - NoSQL (MongoDB) ou SQL (PostgreSQL)
* Tela de listagem dos pedidos
* Todas as informações precisam ser persistidas no banco de dados escolhido.
* Documento descrevendo o processo de instalação do sistema
* O fluxo de autenticação é opcional, o mesmo poderá ser mockado para andamento do projeto.
* O Sistema deverá implementar o fluxo baseado nos arquivos de Design listados no item **Arquivos**

## Microserviço de Cálculo de Frete
O microserviço de cálculo de frete terá um webservice que  receberá a quantidade de itens que foram selecionados e multiplicará por um valor aleatório entre R$5,00 e R$10,00. Retornando assim o valor calculado.

### Exemplo
Foram selecionados 2 itens do Produto A e 1 item do Produto B, logo teremos 3 itens. O valor sorteado foi R$ 8,00. Assim: 3 x R$ 8,00 = R$ 24,00.

## Diferenciais

* Utilização de docker
* Load Balancer
* Utilização do Service Discovery e Api Gateway
* DDD e/ou CQRS
* Desenho Arquitetural
* Escrita de testes

## Arquivos

**GET Request -> Dados do Cliente e Produtos**

	Os JSONs utilizados nessa avaliação estão hospedados e você pode ver mais informações pelo link [https://maximatech.docs.apiary.io](https://maximatech.docs.apiary.io).
  
**Design Mockup**

	URL : https://bit.ly/2P0cw5l
  
**Arquivos de Design**

	URL : https://go.aws/2uvDgkY	

## Design Preview

![Preview](https://raw.githubusercontent.com/talentosmaxima/Fullstack-Developer/master/Design/preview.png)

## Critérios de Avaliação

* Organização do projeto
* Utilização de padrões arquiteturais
* Clareza do código
* Escolha de estruturas e bibliotecas
* Ausência de crashs e bugs
* Detalhes de UI
* Linguagem de programação

## Dúvidas
Entre em contato com talentoshumanos@maximatech.com.br

## Instação do sistema
1. Baixe o arquivo 'ProvaMaximaPublicacao.zip', que se encontra na raiz do projeto e a extraia para o C:\.
![Preview](https://i.ibb.co/9pBJqfT/publicacao.png)
2. Os sistema precisará do IIS(Internet Information Services ) para publicarmos o site local.
	* Primeiro vá em 'Painel de Controle'
	* Procure por 'Programas e Recursos' e clique na opção 'Ativar ou desativar recursos do Windows'
	![Preview](https://i.ibb.co/b2gYKqR/painel-Controle.png)
	* Após clicar nessa opção, na tela que abrir, vá até a opção 'Serviços de Informações da Internet', clique e ative essa opção e dê OK.
	![Preview](https://i.ibb.co/CQ7sXrj/Servico-IIS.png)
3. Depois que ativarmos o IIS do windows, vamos agora baixar o .NET Core Runtime 2.2.0:
* Se sua máquina for 64x, clique no link abaixo (Observação: o link abaixo está no site, o coloquei aqui para facilitar): "https://dotnet.microsoft.com/download/dotnet-core/thank-you/runtime-aspnetcore-2.2.0-windows-x64-installer"
* Se sua máquina for 86x, clique no link abaixo (Observação: o link abaixo está no site, o coloquei aqui para facilitar):
"https://dotnet.microsoft.com/download/dotnet-core/thank-you/runtime-aspnetcore-2.2.0-windows-x86-installer"

4. Agora, a última dependência. O mongoDB server (Observação: o link abaixo está no site, o coloquei aqui para facilitar):
'https://downloads.mongodb.com/win32/mongodb-win32-x86_64-enterprise-windows-64-4.0.21-rc0-signed.msi'

5. Depois de instalar o runtime, entre no IIS(Internet Information Services ):
* Vá sobre  a pasta 'Site', botão direito 'Adicionar Site...'
* Na tela que abrirá, configure o nome, escolha a pasta que descompaquitamos na unidade 'C:\ProvaMaximaPublicacao'
* Defina uma porta que não esteja sendo usada por outra aplicação, no meu caso foi a 8200'
![Preview](https://i.ibb.co/rmTdh0s/COnf.png)
* Após a publicação:
![Preview](https://i.ibb.co/MRsNZjF/Site-Criado.png)
6. Acessando o site já publicado:
* Agora é só acessar o site publicado: 'localhost:8200'
