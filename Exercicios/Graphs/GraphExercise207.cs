namespace Exercicios.Graphs;

public class GraphExercise207
{
    private Dictionary<int, List<int>> mapCoursesAndRequisites = new Dictionary<int, List<int>>(); //Essa variavel vai mapear os cursos e seus requisitos, por exemplo, chave 0 e valor [1,2], quer dizer que o curso 0 precisa do curso 1 e 2 como requisito para ser feito.
    private HashSet<int> visiting = new HashSet<int>(); //Essa variavel vai guardar todos os cursos que ja visitamos no DFS, pois se visitarmos um curso mais de uma vez, quer dizer que ha um ciclo nos requisitos, portanto sera impossivel de fazer todos os cursos.
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        //Aqui populamos todas as chaves do nosso hashMap de cursos e requisitos, ou seja, colocamos todos os cursos como chaves, mas ainda sem seus respectivos pre-requisitos.
        for (int i = 0; i < numCourses; i++) 
        {
            mapCoursesAndRequisites[i] = new List<int>();
        }

        //Agora sim estamos populando as chaves/cursos com seus respectivos pre-requisitos.
        foreach (var prereq in prerequisites) 
        {
            mapCoursesAndRequisites[prereq[0]].Add(prereq[1]); //No array prerequisites, o primeiro elemento eh o curso e o segundo o seu requisito.
        }

        for (int course = 0; course < numCourses; course++) 
        {
            if (!Dfs(course))
                return false;
        }
        return true;
    }

    private bool Dfs(int course) 
    {
        //Como dito acima, ciclo foi detectado quando se visita um curso mais de uma vez. Por isso usamos um hashSet.
        if (visiting.Contains(course))
            return false;

        //Caso o curso nao tenha NENHUM prerequisito, ai ja retornamos true
        if (mapCoursesAndRequisites[course].Count == 0)
            return true;
        
        visiting.Add(course); //Adicionamos o curso atual a nossa variavel de cursos visitados.
        
        foreach (int pre in mapCoursesAndRequisites[course]) //Nos iremos iterar sob todos os prerequisitos do curso atual
        {
            if (!Dfs(pre)) //Aqui estamos verificando se algum dos cursos requisitos retornar falso, nos ja podemos retornar falso para o curso atual tambem, pois se algum curso pre-requisito nao puder ser completado, entao o curso atual tambem nao pode.
                return false;
        }

        visiting.Remove(course); //No final do processo, apos checar todos os requisitos do curso, nos devemos tirar esse curso atual de visiting, pois nos ja terminamos o processo desse curso atual.
        mapCoursesAndRequisites[course].Clear(); //Alem disso, nos podemos tirar todos os requisitos desse curso atual, pois se o codigo chegou ate aqui, eh pq sabemos com certeza que esse curso PODE ser finalizado, entao para proximas iteracoes nao precisamos repetir o processo de analisar se ele pode ou nao ser finalizado, os seus requisitos ja estarao vazios, portanto caira no nosso segundo base-case que checa se os prerequisitos estao vazios.
        return true; //Retornamos true, pois se durante a iteracao checando se todos os prerequisitos nao deu nenhum problema de cair em false, entao isso quer dizer que esse curso eh possivel de ser finalizado.
    }
}
