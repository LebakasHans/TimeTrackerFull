<script>
    import DateTimePicker from '$lib/components/DateTimePicker.svelte';
    import { onMount } from 'svelte';
    import { baseUrl } from '$lib/model/constants.js';
    import { createEventDispatcher } from 'svelte';

    const dispatch = createEventDispatcher();

    export let projectTime;

    let projects = [];
    let activities = [];

    let startDate = '';
    let endDate = '';
    let duration = '';
    let projectId = 0;
    let activityId = 0;
    let description = '';

    $: {
        if (projectTime) {
            startDate = projectTime.startDate;
            endDate = projectTime.endDate;
            projectId = projectTime.projectId;
            activityId = projectTime.activityId;
            description = projectTime.description;
        }
    }

    $: duration = calculateDuration(startDate, endDate);

    function addProjectEntry() {
        if(!projectTime) return;

        let employeeId = projectTime.employeeId;

        const body = {
            startDate,
            endDate,
            projectId,
            activityId,
            description,
            employeeId
        };

        fetch(`${baseUrl}/projectschedule`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(body)
        })
            .then(response => response.json())
            .then(data => {
                dispatch('change', { projectTime: data, method: 'POST'});
            })
            .catch(error => {
                console.error('Error:', error);
            });
    }

    function deleteProjectEntry() {
        if(!projectTime) return;

        fetch(`${baseUrl}/projectschedule/${projectTime.id}`, {
            method: 'DELETE'
        })
            .then(response => response.json())
            .then(data => {
                dispatch('change', { projectTime: data, method: 'DELETE'});
            })
            .catch(error => {
                console.error('Error:', error);
            });
    }

    function updateProjectEntry() {
        if(!projectTime) return;

        const body = {
            startDate,
            endDate,
            projectId,
            activityId,
            description,
            employeeId: projectTime.employeeId
        };

        fetch(`${baseUrl}/projectschedule/${projectTime.id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(body)
        })
            .then(response => response.json())
            .then(data => {
                dispatch('change', { projectTime: data, method: 'PUT'});
            })
            .catch(error => {
                console.error('Error:', error);
            });
    }

    function calculateDuration(start, end) {
        if (!start || !end) return '';

        const startDate = new Date(start.split('.').reverse().join('.'));
        const endDate = new Date(end.split('.').reverse().join('.'));
        
        const diffInMinutes = Math.abs(endDate - startDate) / (1000 * 60);
        const hours = Math.floor(diffInMinutes / 60);
        const minutes = Math.floor(diffInMinutes % 60);
        return `${hours.toString().padStart(2, '0')}:${minutes.toString().padStart(2, '0')}`;
    }

    onMount(async () => {
        fetch(`${baseUrl}/project`)
            .then(response => response.json())
            .then(data => {
                projects = data;
            })
            .catch(error => {
                console.error('Error:', error);
            });

        fetch(`${baseUrl}/activity`)
            .then(response => response.json())
            .then(data => {
                activities = data;
            })
            .catch(error => {
                console.error('Error:', error);
            });
    });

    $: console.log(description);
    $: console.log(projectId);
    $: console.log(activityId);
</script>

<div class="card">
    <div class="card-body">
        <div>
            <span>Project:</span>
            <select bind:value={projectId}>
                {#each projects as project}
                    <option value={project.id}>{project.name}</option>
                {/each}
            </select>
        </div>
        <div>
            <span>Activity:</span>
            <select bind:value={activityId}>
                {#each activities as activity}
                    <option value={activity.id}>{activity.name}</option>
                {/each}
            </select>
        </div>
        <div>
            <span>Start Date:</span>
            <DateTimePicker dateTime={startDate} on:dateTimeChanged={ev => startDate = ev.detail.dateTimeString}/>
        </div>
        <div>
            <span>End Date:</span>
            <DateTimePicker dateTime={endDate} on:dateTimeChanged={ev => endDate = ev.detail.dateTimeString}/>
        </div>
        <div>
            <span>Dauer:</span>
            {duration}
        </div>
        <div>
            <span>Beschreibung:</span>
            <textarea bind:value={description}></textarea>
        </div>

        <div>
            <button on:click={updateProjectEntry}>Save</button>
            <button on:click={deleteProjectEntry}>Delete</button>
            <button on:click={addProjectEntry}>New</button>
        </div>
    </div>
</div>

<style lang="scss">
    @import 'bootstrap/dist/css/bootstrap.min.css';
    @import 'bootstrap-icons/font/bootstrap-icons.min.css';
</style>