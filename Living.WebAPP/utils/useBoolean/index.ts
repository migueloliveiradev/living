import { ref } from "vue";

export function useBoolean(value = false): [Ref<boolean>, () => void, () => void] {
	const boolean = ref(value);

	const setTrue = () => {
		boolean.value = true;
	};

	const setFalse = () => {
		boolean.value = false;
	};

	return [boolean, setTrue, setFalse];
}
