#include <stdio.h>
 int main(){

   // Declara o vetor1 com 5 valores reais já definidos
   // Declara o vetor2 com 5 valores reais já definidos
   // Declara o vetor3 vazio para armazenar as médias
   // Declara a variável media iniciando com 0
   // Declara a variável soma iniciando com 0
   float vetor1 [5] = {33, 21, 45, 13, 3}, vetor2 [5]= {8, 4, 16, 28, 12}; float vetor3 [5], media=0, soma=0;
   int cont;

   // Laço de repetição que percorre as 5 posições dos vetores
   for (cont = 0; cont < 5; cont++){

       // Calcula a média entre os valores de mesma posição dos vetores 1 e 2 e armazena o resultado no vetor3
      vetor3[cont] = (vetor1[cont]+ vetor2[cont])/2;

      // Exibe o valor armazenado em cada posição do vetor3
        printf("O valor da posição %d do vetor 3 é: %0.2f\n", cont, vetor3[cont]);

      // Soma os valores do vetor3 para depois calcular a média final
        soma = soma + vetor3[cont];
   }

    // Calcula a média dos valores armazenados no vetor3
   media = (media +soma)/5;

   // Exibe a média final do vetor3
   printf("\nA média do vetor 3 é: %0.2f", media);
   
    return 0;
 }