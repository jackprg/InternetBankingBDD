#language: pt-br

Funcionalidade: Enviar Pix
	Enviar um pix para outra pessoa a partir do Internet Banking

@Robo
Cenario: Em um pix realizado com sucesso deverá ser exibido para o usuario o comprovante do pix
	Dado que sou um usuário do Internet Banking
	E acessei a feature de envio de pix
	E selecionei o tipo de chave
	E informei a chave
	E informei o valor
	Quando clicar na opção enviar
	Então o comprovante de pix deve ser exibido
