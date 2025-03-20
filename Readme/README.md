# Jogo de Baralho

## Como rodar o projeto APIJogoBaralho

1. Clone o repositório.
2. De o start no projeto em modo de container(Dockerfile) .
3. Acesse a API pela URL que o Docker atribuir.

## Endpoints

- **POST /api/jogo/criar-baralho**: Cria um novo baralho.
- **POST /api/jogo/distribuir-cartas?numeroDeJogadores={n}**: Distribui cartas para N jogadores.
- **POST /api/jogo/finalizar-jogo?baralhoId={id}**: Finaliza o jogo e retorna as cartas ao baralho.