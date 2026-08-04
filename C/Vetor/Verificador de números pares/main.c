#include <stdio.h>

int main(){
    
    int vetor_num[5], cont;
    
    
    for(cont = 0;cont < 5; cont++ ){
        
    printf("Digite um número inteiro: ");
    scanf("%d", &vetor_num[cont]);
    
    }
    
    if(vetor_num[cont] %2 == 0){
        
        printf("Os números pares são %d", vetor_num[cont]);
    }
    
    else{   
    
        printf("São ímpares %d ", vetor_num[cont]);
    }
    return 0;
}