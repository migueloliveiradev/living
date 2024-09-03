import type { Notification } from "~/composables/useApi/types";

export interface FormErrorProps {
  errors: Notification;
  keys: string[];
}
