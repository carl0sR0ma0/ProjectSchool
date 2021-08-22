<template>
  <div>
    <Titulo text="Sobre" :btnVoltar="true" />
    <p>
      Lorem ipsum dolor, sit amet consectetur adipisicing elit. Laboriosam
      molestiae voluptatibus voluptate non, inventore temporibus eius ex
      exercitationem quibusdam vero laudantium optio omnis fugiat beatae
      officiis. Blanditiis doloribus earum fugiat.
    </p>
    <p>
      Lorem ipsum, dolor sit amet consectetur adipisicing elit. Nesciunt,
      ducimus maiores harum natus quo asperiores, incidunt delectus rerum
      ratione dolor ipsa porro ad atque. Dolorem voluptates tempore voluptatibus
      beatae maiores.
    </p>
  </div>
</template>

<script>
import Titulo from "../shared/Titulo.vue";
export default {
  components: { Titulo },
};
</script>

<style scoped>
</style>