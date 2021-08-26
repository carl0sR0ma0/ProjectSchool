<template>
  <!-- Carrega a div se o professor for carregado -->
  <div v-if="!loading">
    <Titulo :text="`Aluno: ${aluno.nome}`" :btnVoltar="!editavel">
      <button v-show="editavel" class="btn btnEditar" @click="editar()">
        Editar
      </button>
    </Titulo>

    <table>
      <tbody>
        <tr>
          <td class="colPequeno">Matrícula:</td>
          <td>
            <label>{{ aluno.id }}</label>
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Nome:</td>
          <td>
            <label v-if="editavel">{{ aluno.nome }}</label>
            <input v-else v-model="aluno.nome" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Sobrenome:</td>
          <td>
            <label v-if="editavel">{{ aluno.sobrenome }}</label>
            <input v-else v-model="aluno.sobrenome" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Data Nascimento:</td>
          <td>
            <label v-if="editavel">{{ aluno.dataNasc }}</label>
            <input v-else v-model="aluno.dataNasc" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Professor:</td>
          <td>
            <label v-if="editavel">{{ aluno.professor.nome }}</label>
            <select v-else v-model="aluno.professor.id">
              <option
                v-for="(professor, index) in professores"
                :key="index"
                :value="professor.id"
              >
                {{ professor.nome }}
              </option>
            </select>
          </td>
        </tr>
      </tbody>
    </table>

    <div style="margin-top: 10px">
      <div v-if="!editavel">
        <button class="btn btnSalvar" @click="salvar()">Salvar</button>
        <button class="btn btnCancelar" @click="cancelar()">Cancelar</button>
      </div>
    </div>
  </div>
</template>

<script>
import Titulo from "../shared/Titulo.vue";
export default {
  components: { Titulo },
  data() {
    return {
      editavel: true,
      professores: [],
      aluno: {},
      idAluno: this.$route.params.id,
      loading: true,
    };
  },
  created() {
    this.carregarProfessor();
  },
  methods: {
    carregarProfessor() {
      this.$http
        .get("http://localhost:5000/professor")
        .then((res) => res.json())
        .then((professores) => {
          this.professores = professores;
          this.carregarAluno();
        });
    },
    carregarAluno() {
      this.$http
        .get(`http://localhost:5000/aluno/${this.idAluno}`)
        .then((res) => res.json())
        .then((aluno) => {
          this.aluno = aluno;
          this.loading = false;
        })
        .then(() => this.editavel = true);
    },
    editar() {
      this.editavel = !this.editavel;
    },
    salvar() {
      let _alunoEditar = {
        id: this.aluno.id,
        nome: this.aluno.nome,
        sobrenome: this.aluno.sobrenome,
        dataNasc: this.aluno.dataNasc,
        professorId: this.aluno.professor.id,
      };

      this.$http
        .put(`http://localhost:5000/aluno/${_alunoEditar.id}`, _alunoEditar)
        .then((res) => res.json())
        .then((aluno) => (this.aluno = aluno));
      this.editavel = !this.editavel;
    },
    cancelar() {
      this.editavel = !this.editavel;
    },
  },
};
</script>

<style scoped>
.colPequeno {
  width: 20%;
}

input,
select {
  margin: 0px;
  padding: 5px 10px;
  font-size: 0.9em;
  border: 1px solid silver;
  border-radius: 5px;
  outline: none;
  font-family: Montserrat;
  background-color: rgb(245, 245, 245);
  width: 95%;
}

select {
  height: 38px;
  width: 100%;
}

.btnEditar {
  float: right;
  background-color: rgb(76, 186, 249);
}

.btnSalvar {
  float: right;
  background-color: rgb(76, 196, 68);
}

.btnCancelar {
  float: left;
  background-color: rgb(249, 186, 92);
}
</style>