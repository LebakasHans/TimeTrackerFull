<script>
  import { onMount } from 'svelte';
  import { baseUrl } from '$lib/model/constants.js';

  export let inputSize = 4;
  export let selectedEmployee = null;

  let employees = [];
  let filteredEmployees = [];
  let filter = '';

  $: filteredEmployees = employees
    .filter(employee => employee.name.toLowerCase().includes(filter.toLowerCase()))
    .sort((a, b) => a.name.localeCompare(b.name));

  onMount(async () => {
    fetch(`${baseUrl}/employees`)
      .then(response => response.json())
      .then(data => {
        employees = data;
      })
      .catch(error => {
        console.error('Error:', error);
      });
  });
</script>

<div>
  <div>
    <input type="text" placeholder="Filter employees" bind:value={filter} />
  </div>

  <div>
    <select size={inputSize} bind:value={selectedEmployee}>
      {#each filteredEmployees as employee}
        <option value={employee} >{employee.name}</option>
      {/each}
    </select>
</div>
</div>