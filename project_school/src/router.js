import Vue from "vue";
import Router from "vue-router";
import Alunos from "./components/Aluno/Alunos";
import AlunoDetalhe from "./components/Aluno/AlunoDetalhe";
import Professor from "./components/Professor/Professor";
import Sobre from "./components/Sobre/Sobre.vue";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/professores",
      name: "Professores",
      component: Professor,
    },
    {
      path: "/alunos",
      name: "Alunos",
      component: Alunos,
    },
    {
      path: "/alunoDetalhe/:id",
      name: "AlunoDetalhe",
      component: AlunoDetalhe,
    },
    {
      path: "/alunos/:prof_id",
      name: "Alunos",
      component: Alunos,
    },
    {
      path: "/sobre",
      name: "Sobre",
      component: Sobre,
    },
  ],
});
