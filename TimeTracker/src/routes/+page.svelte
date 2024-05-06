<script>
  import EmployeeList from '$lib/components/EmployeeList.svelte';
  import EmployeeCard from '$lib/components/EmployeeCard.svelte';
  import AddProjectEntry from '$lib/components/AddProjectEntry.svelte';
  import ProjectTable from '$lib/components/ProjectTable.svelte';

  let selectedEmployee = null;
  let selectedProjectTime = {};

  function log(event) {
    console.log(event.detail);
  }
</script>

<div class="container">
  <div class="flex">
    <span class="mr">
      <EmployeeList inputSize="4" bind:selectedEmployee={selectedEmployee}/>
    </span>
    <EmployeeCard employee={selectedEmployee}/>

    <AddProjectEntry bind:projectTime={selectedProjectTime} on:change={log}/>
  </div>

  <ProjectTable employeeId={selectedEmployee?.id} bind:selectedProject={selectedProjectTime} />
</div>



<style>
  .container {
    margin: 1rem;
  }

  .mr{
    margin-right: 1rem;
  }

  .flex {
    display: flex;
  }
</style>