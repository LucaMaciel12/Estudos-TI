#include<stdio.h>
int main(){
    
    float nota1,nota2,nota3;
    int cont,quant;
    
    printf("Quantos alunos você deseja calcular média?\n");
    scanf("%d",&quant);
    
    for(cont = 1; cont <= quant; cont++){
        
        printf("Digite as nota do aluno: ");
        scanf("%f", &nota1);
        
        printf("Digite as nota do aluno: ");
        scanf("%f", &nota2);
        
        printf("Digite as nota do aluno: ");
        scanf("%f", &nota3);
        
        printf("A média do aluno %d é de: %.2f\n", cont, (nota1+nota2+nota3)/3);
    }
    
    printf("\nO programa encerrou");
    
    return 0;
}