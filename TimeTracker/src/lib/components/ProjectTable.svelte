<script>
    import { baseUrl } from '$lib/model/constants.js';

    export let employeeId;
    export let selectedProject;

    $: updateTable(employeeId);

    let projects = [];

    function updateTable(employeeId) {
        if (!employeeId) return;

        fetch(`${baseUrl}/projectschedules?employeeId=${employeeId}`)
            .then(response => response.json())
            .then(data => {
                projects = data;
            })
            .catch(error => {
                console.error('Error:', error);
            });
    }
</script>

<table>
    <thead>
        <tr>
            <th>Id</th>
            <th>ProjectId</th>
            <th>EmployeeId</th>
            <th>ActivityId</th>
            <th>Description</th>
            <th>EmployeeName</th>
            <th>ProjectName</th>
            <th>ActivityName</th>
            <th>StartDate</th>
            <th>EndDate</th>
        </tr>
    </thead>
    <tbody>
        {#each projects as project}
            <tr class:selected={project.id === selectedProject.id} on:click={_ => selectedProject = project}>
                <td>{project.id}</td>
                <td>{project.projectId}</td>
                <td>{project.employeeId}</td>
                <td>{project.activityId}</td>
                <td>{project.description}</td>
                <td>{project.employeeName}</td>
                <td>{project.projectName}</td>
                <td>{project.activityName}</td>
                <td>{project.startDate}</td>
                <td>{project.endDate}</td>
            </tr>
        {/each}
    </tbody>
</table>

<style>
    table {
        width: 100%;
        border-collapse: collapse;
    }

    th, td {
        border: 1px solid black;
        padding: 0.5rem;
    }

    th {
        background-color: #f1f1f1;
    }

    tr:nth-child(even) {
        background-color: #f2f2f2;
    }

    tr:hover {
        background-color: #748797;
    }

    tr.selected {
        background-color: #ffcc00;
    }
</style>