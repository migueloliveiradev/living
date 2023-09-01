<script setup lang="ts">

</script>
<template>
    <div class="friends-online mb-3">
        <p class="text-center m-1">Amigos Online</p>
        <div class="d-flex  overflow-x-auto">
            <img class="rounded-circle" src="/eimigueloliveir.png" alt="friend" width="50" height="50" />
            <img class="rounded-circle" src="/eimigueloliveir.png" alt="friend" width="50" height="50" />
            <img class="rounded-circle" src="/eimigueloliveir.png" alt="friend" width="50" height="50" />
            <img class="rounded-circle" src="/eimigueloliveir.png" alt="friend" width="50" height="50" />
            <img class="rounded-circle" src="/eimigueloliveir.png" alt="friend" width="50" height="50" />
            <img class="rounded-circle" src="/eimigueloliveir.png" alt="friend" width="50" height="50" />
            <img class="rounded-circle" src="/eimigueloliveir.png" alt="friend" width="50" height="50" />
        </div>
    </div>
</template>
<style>
.friends {
    border-radius: 10px;
    border: 1px solid #f6f6f669;
    width: 250px;
    height: 80vh;
}


.friend {
    display: flex;
    align-items: center;
    padding: 10px;
    cursor: pointer;
    border: 1px solid #f6f6f669;
    margin: 10px;
    border-radius: 10px;
}

.chat {
    border-radius: 10px;
    border: 1px solid #f6f6f669;
    width: 100%;
    height: 80vh;
}

.messages {

    padding: 10px;
}

.message-content {
    border-radius: 20px;
    padding: 10px 10px 10px 10px;
    margin-left: 10px;
    border: 1px solid #f6f6f669;
}

.message-image {
    margin-top: 7px;
}

.message-time {
    font-size: 12px;
    margin-right: 10px;
}
</style>