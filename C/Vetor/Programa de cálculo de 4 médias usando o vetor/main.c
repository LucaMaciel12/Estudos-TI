#include <stdio.h>

int main()
{
    float notas[4], media, soma =0;
    int cont;


    for(cont = 0; cont < 4; cont++){
     
     printf("Digite a nota do aluno %d: ", cont);
     scanf("%f", &notas[cont]);
     soma = soma + notas[cont];
    }
    
    for(cont = 0; cont < 4; cont++){
        printf("%.2f \t",notas[cont]);
    }
    
    media = soma / 5;
    printf("\n\nA média do aluno foi de: %0.2f", media);
    
    if(media >= 7){
        printf("\n\nO aluno foi aprovado.");
    }
    else{
        printf("\n\nO aluno foi reprovado.");
    }
    
    


    return 0;
}
