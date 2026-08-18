## Mapeamento de Padrões Aplicados e Sua Justificativa

### Requisito 1

Utilizei os padrões `Observer`, `State` e `Command`.

O padrão `Observer` encaixa perfeitamente no contexto dos sistemas da nave, pois precisam estar atentos ao estado do núcleo de energia para seu funcionamento, checando cada alteração de status da nave, sem que a nave os gerencie diretamente. O padrão `State` permite mudar o comportamento dos sistemas da nave a partir do estado interno do núcleo. Por fim, o padrão `Command` ajuda a lidar com vários inputs, criando uma ligação direta entre "input" e "ação" (O(1) e baixo boilerplate), permitindo o isolamento da lógica de cada ação e mantendo um menu mais "claro".

### Requisito 2

Com a restrição de destruir o objeto tripulante para criar um novo com o novo cargo, o padrão `Strategy` foi essencial para selecionar um novo cargo mantendo o objeto, permitindo o objeto cargo ser intercambiável em tempo de execução. Em adição, o padrão `Factory` é aplicado de maneira simples, porém suficiente para o contexto, complementando a criação dos cargos e desacoplando do Manager a obrigatoriedade de utilizar uma classe concreta a partir de uma interface.

### Requisito 3

A implementação de armas seguiu a lógica parecida aos cargos, de intercambialidade de objetos em tempo de execução, logo, a escolha pelo padrão `Strategy` foi natural, assim como o padrão `Factory` para dar suporte a ele. A novidade nesse requisito foi a utilização do padrão `Decorator`, que permitiu o encapsulamento do objeto por outro que implementa a mesma interface (modificadores), assim criando o efeito de pilha/acumulação dos modificadores.

---

## Identificação dos Papéis no Código

### 1. Strategy

O padrão aparece em dois lugares distintos do projeto.

O primeiro é nos cargos da tripulação. A interface da estratégia é `ICargo`. As estratégias concretas são `PilotoNave`, `Medico`, `OperadorCanhoes`, `EngenheiroEscudos`, `MecanicoMotor` e `Cozinheiro`. O contexto é `Tripulante`, que mantém a estratégia atual na propriedade `CargoAtual` e delega o comportamento a ela. A troca de estratégia em tempo de execução acontece pelo método `Tripulante.MudarCargo(ICargo novoCargo)`.

O segundo é nas armas da nave. A interface da estratégia é `IArma`. As estratégias concretas, nesse caso, são as armas base `LaserContinuo` e `EnxameMisseis` — cada uma implementa `Atirar()` com um algoritmo de disparo diferente. O contexto é `Nave`, que mantém a estratégia atual na propriedade `Arma` e delega o disparo a ela através do método `Nave.Atirar()`. A troca de estratégia em tempo de execução acontece quando `ArmamentoManager.CriarArma` reatribui `nave.Arma` a uma nova arma escolhida pelo usuário.

Vale diferenciar esse uso do Decorator descrito a seguir: o Strategy decide qual arma base está equipada (uma de cada vez, por completo), enquanto o Decorator, aplicado sobre o resultado do Strategy, adiciona camadas de efeito à arma já escolhida.

### 2. Factory (Simple Factory)

O produto criado é representado pelas interfaces `IArma` e `ICargo`. Os produtos concretos são `LaserContinuo` e `EnxameMisseis`, no caso das armas, e `PilotoNave`, `Medico`, `OperadorCanhoes`, `EngenheiroEscudos`, `MecanicoMotor` e `Cozinheiro`, no caso dos cargos. A criação fica centralizada em `ArmaFactory.CriarArma(int)` e `CargoFactory.Criar(int)`. Quem consome essas fábricas é `ArmamentoManager.CriarArma` e `TripulacaoManager.SelecionarCargo`.

### 3. Decorator

O componente comum é a interface `IArma`. O componente concreto, sem decoração, é representado por `LaserContinuo` e `EnxameMisseis`. A classe base do decorator é `ModificadorArma`, que guarda a referência ao componente decorado. Os decorators concretos são `DanoFogo` e `PerfuracaoBlindagem`. Quem monta a composição de decorators é `ArmaFactory.AplicarModificador(IArma, int)`.

### 4. State

A interface comum dos estados é `IEstadoNucleo`. Os estados concretos são `EstadoNormal` e `EstadoCritico`. O contexto que mantém e delega ao estado atual é `NucleoEnergia`, através do campo `_estado`. A transição de estado ocorre em `NucleoEnergia.MudarEstado(IEstadoNucleo)`, acionada pelo método `VerificaEstado()`.

### 5. Observer

A interface comum dos observadores é `ISistema`. Os observadores concretos são `Escudo`, `Luzes` e `PainelNavegacao`. O sujeito observável, que mantém a lista de observadores e os notifica, é `NucleoEnergia`, através do campo `_observers`. O registro de observadores acontece em `NucleoEnergia.AdicionarSistema(ISistema)`, e a notificação em `NucleoEnergia.NotificarObservers(EventoNucleo)`, que chama `ISistema.Atualizar(...)`. O dado transmitido na notificação é o enum `EventoNucleo`, com os valores `DanoRecebido`, `EnergiaAlterada` e `EnergiaRecuperada`.

### 6. Command

A interface comum dos comandos é `IComando`. Os comandos concretos são `ComandoTomarDano`, `ComandoReduzirEnergia`, `ComandoRecuperarEnergia` e `ComandoTripulante`. O receptor, que efetivamente executa a ação, é `NucleoEnergia` para os três primeiros comandos, e `Nave`/`TripulacaoManager` para `ComandoTripulante`. Quem cria e dispara os comandos (o invocador) é `MenuPrincipal`, ao interpretar o comando digitado pelo usuário.

Vale observar que `ComandoTripulante` é um comando concreto válido, mas não é utilizado por nenhum invocador no fluxo atual da aplicação — `MenuPrincipal` chama `MenuTripulacao.Instance.Exibir` diretamente, sem passar por um `IComando`.

### 7. Singleton

As classes que aplicam o padrão são `MenuPrincipal`, `MenuArmamento` e `MenuTripulacao`, cada uma como seu próprio singleton independente. O mecanismo de instância única é o campo estático privado `_instance`, combinado com a propriedade `Instance`, que faz a inicialização preguiçosa (`_instance ??= new ...()`). A instanciação externa é impedida pelo construtor `private` em cada uma das três classes.

---

## Instruções de Execução

### Requisitos

- .NET SDK 10.0 ou superior
- Git (para clonar o repositório)

### Como Configurar e Rodar

#### 1. Clonar o Repositório

```bash
git clone https://github.com/thinito/Desafio-LabTIME-2026.git
cd Desafio-LabTIME-2026
```

#### 2. Compilar o Projeto

**Opção A: Usando .NET CLI (Recomendado)**
```bash
dotnet build
```

**Opção B: Usando Visual Studio**
- Abra `Desafio-LabTIME-2026.slnx` no Visual Studio 2022+
- Pressione `Ctrl + Shift + B` para compilar

#### 3. Executar a Demonstração

**Opção A: Usando .NET CLI**
```bash
dotnet run --project SpacefightApp
```

**Opção B: Usando Visual Studio**
- Pressione `F5` ou clique em "Start Debugging"

**Opção C: Executar o binário compilado**
```bash
# Windows
./SpacefightApp/bin/Debug/net10.0/SpacefightApp.exe

# Linux/macOS
./SpacefightApp/bin/Debug/net10.0/SpacefightApp
```

### Como Jogar

Após iniciar, você terá acesso a um menu interativo:

**Menu Principal:**
```
Comandos: tomar_dano <valor> | reduzir_energia | recuperar_energia | tripulacao | armamento | status | sair
```

**Menu de Armamento:**
```
Comandos: equipar_arma <num.Arma> | adicionar_modificador <num.Modificador> | atirar | status | voltar
```

**Menu de Tripulantes:**
```
Comandos: mudar_cargo <num.Tripulante> <num.Cargo> | trabalhar <num.Tripulante> | voltar
```
