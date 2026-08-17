# Documentação Resumida — SpacefightApp

## Visão Geral

SpacefightApp é uma aplicação de console em C# (.NET 10) que simula o painel de controle de uma nave espacial. O usuário interage por menus de texto para gerenciar energia, tripulação e armamento da nave.

- **Ponto de entrada:** `Program.Main()`
- **Padrões de projeto usados:** Singleton (menus), Factory (`ArmaFactory`, `CargoFactory`), Decorator (modificadores de arma), State (estados do núcleo), Observer (sistemas da nave), Command (ações do menu principal)

## Estrutura de Pacotes

| Pacote | Conteúdo |
|---|---|
| `Armamento` | Gerenciamento de armas equipadas |
| `Armamento.Armas` | Tipos de arma e fábrica de armas |
| `Armamento.Mods` | Modificadores aplicáveis às armas |
| `Comandos` | Ações executáveis sobre a nave |
| `Menus` | Telas de interação com o usuário |
| `NaveEspacial` | Classe central da nave |
| `Nucleo` | Energia da nave e seus eventos |
| `Nucleo.Estados` | Estados do núcleo de energia |
| `Sistema` | Sistemas que reagem a eventos do núcleo |
| `Tripulacao` | Tripulantes e seu gerenciamento |
| `Tripulacao.Cargos` | Cargos que um tripulante pode assumir |

## Classes Principais

### Nave
Representa a nave. Contém o núcleo de energia, a lista de tripulantes e a arma equipada. Ao ser criada, já inicia com sistemas registrados e tripulação padrão.

### NucleoEnergia
Controla o nível de energia da nave (começa em 100). Aplica dano, reduz ou recupera energia, muda de estado (normal ou crítico) e notifica os sistemas da nave sempre que algo muda.

### IEstadoNucleo (EstadoNormal / EstadoCritico)
Define o comportamento do núcleo conforme o nível de energia. Abaixo de 30, o núcleo entra em estado crítico.

### ISistema (Escudo / Luzes / PainelNavegacao)
Sistemas da nave que reagem às mudanças de energia, exibindo mensagens no console (ex.: alertas, luzes apagando, escudos em modo de defesa).

### IArma (LaserContinuo / EnxameMisseis)
Armas que podem ser equipadas na nave, cada uma com seu próprio efeito de disparo.

### ArmaFactory / ArmamentoManager
Criam armas e aplicam modificadores à arma da nave a partir de códigos numéricos escolhidos pelo usuário.

### ModificadorArma (DanoFogo / PerfuracaoBlindagem)
Modificadores que "envolvem" uma arma existente, adicionando efeitos extras ao disparo (queimadura ou perfuração de blindagem).

### Tripulante
Representa um membro da tripulação, com nome e cargo atual.

### ICargo (PilotoNave / Medico / OperadorCanhoes / EngenheiroEscudos / MecanicoMotor / Cozinheiro)
Cargos que um tripulante pode exercer, cada um com sua própria ação de trabalho.

### CargoFactory / TripulacaoManager
Criam cargos e gerenciam a lista de tripulantes (listar, trocar de cargo, executar trabalho).

### MenuPrincipal / MenuArmamento / MenuTripulacao
Telas de console (Singletons) que leem comandos do usuário e acionam as ações correspondentes na nave, no armamento ou na tripulação.

