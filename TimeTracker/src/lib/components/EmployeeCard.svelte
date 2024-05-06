<script>
    export let employee = null;
</script>

{#if employee}
    <div class="card">
        <div class="card-body">
            <h5 class="card-title">{employee.name}</h5>
            <p class="card-text">Employee Id: {employee.id}</p>
            <hr>
            <p class="card-text">Geburtsdatum: {new Date(employee.birthdate).toLocaleDateString('de-DE', { day: '2-digit', month: '2-digit', year: 'numeric' })}</p>
            <p class="card-text">Hours of work: {employee.hoursOfWork}</p>
        </div>
    </div>
{/if}

<style lang="scss">
    @import 'bootstrap/dist/css/bootstrap.min.css';
    @import 'bootstrap-icons/font/bootstrap-icons.min.css';
</style>