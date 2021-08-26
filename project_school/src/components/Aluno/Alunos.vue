<template>
  <div>
    <Titulo
      :text="
        professorId != undefined
          ? 'Professor: ' + professor.nome
          : 'Todos os Alunos'
      "
      :btnVoltar="true"
    />
    <div v-if="professorId != undefined">
      <input
        type="text"
        placeholder="Nome do Aluno"
        v-model="nome"
        @keyup.enter="addAluno()"
      />
      <button class="btn btnInput" @click="addAluno()">Adicionar</button>
    </div>

    <table>
      <thead>
        <th>Mat.</th>
        <th>Nome</th>
        <th>Opções</th>
      </thead>
      <tbody v-if="alunos.length">
        <tr v-for="(aluno, index) in alunos" :key="index">
          <td class="colPequeno">{{ aluno.id }}</td>
          <router-link
            :to="`/alunoDetalhe/${aluno.id}`"
            tag="td"
            style="cursor: pointer"
          >
            {{ aluno.nome }} {{ aluno.sobrenome }}
          </router-link>
          <td class="colPequeno">
            <button class="btn btnDanger" @click="remove(aluno)">
              Remover
            </button>
          </td>
        </tr>
      </tbody>
      <tfoot v-else>
        <tr>
          <td colspan="3" style="text-align: center">
            <h5>Nenhum Aluno Encontrado</h5>
          </td>
        </tr>
      </tfoot>
    </table>
  </div>
</template>

<script>
import Titulo from "../shared/Titulo.vue";
export default {
  components: {
    Titulo,
  },
  data() {
    return {
      titulo: "Aluno",
      professorId: this.$route.params.prof_id,
      professor: {},
      nome: "",
      alunos: [],
    };
  },
  created() {
    if (this.professorId) {
      this.carregarProfessor();
      this.$http
        .get(`http://localhost:5000/aluno/ByProfessor/${this.professorId}`)
        .then((res) => res.json())
        .then((alunos) => (this.alunos = alunos));
    } else {
      this.$http
        .get("http://localhost:5000/aluno")
        .then((res) => res.json())
        .then((alunos) => (this.alunos = alunos));
    }
  },
  props: {},
  methods: {
    addAluno() {
      let _aluno = {
        nome: this.nome,
        sobrenome: "",
        dataNasc: "",
        professorId: this.professor.id
      };

      this.$http
        .post("http://localhost:5000/aluno", _aluno)
        .then((res) => res.json())
        .then((aluno) => {
          this.alunos.push(aluno);
          this.nome = "";
        });
    },
    remove(aluno) {
      this.$http.delete(`http://localhost:5000/aluno/${aluno.id}`).then(() => {
        let indice = this.alunos.indexOf(aluno);
        this.alunos.splice(indice, 1);
      });
    },
    carregarProfessor() {
      this.$http
        .get("http://localhost:5000/professor/" + this.professorId)
        .then((res) => res.json())
        .then((professor) => {
          this.professor = professor;
        });
    },
  },
};
</script>

<style scoped>
input {
  width: calc(100% - 195px);
  border: 0;
  padding: 20px;
  font-size: 1.3em;
  color: #687f7f;
  display: inline;
  outline: 0;
}

.btnInput {
  width: 150px;
  border: 0px;
  padding: 20px;
  font-size: 1.3em;
  display: inline;
  background-color: rgb(116, 115, 115);
}

.btnInput:hover {
  padding: 20px;
  margin: 0;
  border: 0;
}
</style>
