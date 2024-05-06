<script>
    import { createEventDispatcher } from 'svelte';
    const dispatch = createEventDispatcher();

    let selectedDate = '';
    let selectedTime = '';
    export let dateTime = '';

    $: {
        if (dateTime) {
            selectedDate = dateTime.split('T')[0];
            selectedTime = dateTime.split('T')[1];
        }
    }

    function updateDateTime() {
        let dateTimeString = `${selectedDate}T${selectedTime}`;
        dispatch('dateTimeChanged', {  dateTimeString });
    }
</script>

<div>
    <input type="date" id="date" placeholder="Datum" bind:value={selectedDate} on:change={updateDateTime}/>
    <input type="time" id="time" placeholder="Zeit" bind:value={selectedTime} on:change={updateDateTime}/>
    <button on:click={() => {
        const now = new Date();
        selectedDate = now.toISOString().split('T')[0];
        selectedTime = now.toTimeString().split(' ')[0];
        updateDateTime();
    }}>Now</button>
</div>