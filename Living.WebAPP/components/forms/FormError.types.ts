import type { Notification } from "~/composables/useApi";

export interface FormErrorProps {
  errors: Notification;
  keys: string[];
}
