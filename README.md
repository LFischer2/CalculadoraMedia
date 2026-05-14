# Calculadora de Médias

Projeto desenvolvido para a disciplina de Programação Orientada a Objetos em C#.

## Descrição
Aplicação para cálculo de média semestral e média final de alunos, seguindo regras acadêmicas e seguindo as condições.

## Funcionalidades
- Cálculo da Média Semestral
- Cálculo da Média Final (Média Semestral + Exame)
- Exibição de status (Aprovado, Exame, Reprovado)
- Validação de entrada de dados

## Regras de Negócio
- Média Semestral = (NP1 * 0.4) + (NP2 * 0.4) + (PIM * 0.2)
- Se a média >= 7 → Aprovado
- Se a média < 7 → Exame
- Média Final = (Média Semestral + Exame) / 2
- Se a média final >= 5 → Aprovado
- Se não → Reprovado

## Estrutura
- Interface (WinForms)
- Lógica de cálculo (POO)

## Tecnologias
- C#
- .NET
- Windows Forms
