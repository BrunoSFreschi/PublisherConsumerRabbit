# Publisher

# RabbitMQ Publisher/Consumer em C#

Este projeto demonstra o uso do RabbitMQ para envio (Publisher) e recebimento (Consumer) de mensagens em uma fila, utilizando a biblioteca `RabbitMQ.Client` em C#.

## 📌 Pré-requisitos
Antes de executar o projeto, certifique-se de ter:

- .NET SDK instalado
- RabbitMQ instalado e em execução (padrão: `localhost`)

## 🚀 Configuração e Execução

### 1️⃣ Instalar Dependências
Caso ainda não tenha a biblioteca do RabbitMQ instalada, adicione-a ao projeto com o seguinte comando:
```sh
 dotnet add package RabbitMQ.Client
```

### 2️⃣ Executar o Consumer
Para iniciar o consumidor que receberá as mensagens da fila, execute:
```sh
 dotnet run --project <nome_do_projeto> Consumer <nome_da_fila>
```
Substitua `<nome_da_fila>` pelo nome da fila desejada.

### 3️⃣ Executar o Publisher
Para enviar mensagens para a fila, execute:
```sh
 dotnet run --project <nome_do_projeto> Delivery <nome_da_fila> "Sua mensagem"
```
Exemplo:
```sh
 dotnet run --project <nome_do_projeto> Delivery minha_fila "Hello, RabbitMQ!"
```

## 📜 Funcionamento
### Consumer (`Consumer`)
- Conecta ao RabbitMQ.
- Declara uma fila.
- Escuta mensagens da fila e imprime no console.

### Publisher (`Delivery`)
- Conecta ao RabbitMQ.
- Declara uma fila.
- Envia uma mensagem para a fila.

## 🔧 Possíveis Erros e Soluções
- **Erro de conexão:** Certifique-se de que o RabbitMQ está em execução.
- **Mensagens não sendo recebidas:** Verifique se o consumidor está ouvindo a fila correta.

## 📖 Referências
- [RabbitMQ Documentation](https://www.rabbitmq.com/)
- [RabbitMQ .NET Client](https://www.nuget.org/packages/RabbitMQ.Client/)

