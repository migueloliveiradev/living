/**
 * This file was auto-generated by openapi-typescript.
 * Do not make direct changes to the file.
 */

export interface paths {
	"/api/auth/register": {
		parameters: {
			query?: never;
			header?: never;
			path?: never;
			cookie?: never;
		};
		get?: never;
		put?: never;
		post: {
			parameters: {
				query?: never;
				header?: never;
				path?: never;
				cookie?: never;
			};
			requestBody?: {
				content: {
					"application/json": components["schemas"]["RegisterUserCommand"];
					"text/json": components["schemas"]["RegisterUserCommand"];
					"application/*+json": components["schemas"]["RegisterUserCommand"];
				};
			};
			responses: {
				/** @description OK */
				200: {
					headers: {
						[name: string]: unknown;
					};
					content: {
						"text/plain": components["schemas"]["GuidBaseResponse"];
						"application/json": components["schemas"]["GuidBaseResponse"];
						"text/json": components["schemas"]["GuidBaseResponse"];
					};
				};
			};
		};
		delete?: never;
		options?: never;
		head?: never;
		patch?: never;
		trace?: never;
	};
	"/api/auth/login": {
		parameters: {
			query?: never;
			header?: never;
			path?: never;
			cookie?: never;
		};
		get?: never;
		put?: never;
		post: {
			parameters: {
				query?: never;
				header?: never;
				path?: never;
				cookie?: never;
			};
			requestBody?: {
				content: {
					"application/json": components["schemas"]["LoginUserCommand"];
					"text/json": components["schemas"]["LoginUserCommand"];
					"application/*+json": components["schemas"]["LoginUserCommand"];
				};
			};
			responses: {
				/** @description OK */
				200: {
					headers: {
						[name: string]: unknown;
					};
					content: {
						"text/plain": components["schemas"]["BaseResponse"];
						"application/json": components["schemas"]["BaseResponse"];
						"text/json": components["schemas"]["BaseResponse"];
					};
				};
			};
		};
		delete?: never;
		options?: never;
		head?: never;
		patch?: never;
		trace?: never;
	};
	"/api/auth/refresh-token": {
		parameters: {
			query?: never;
			header?: never;
			path?: never;
			cookie?: never;
		};
		get?: never;
		put?: never;
		post: {
			parameters: {
				query?: never;
				header?: never;
				path?: never;
				cookie?: never;
			};
			requestBody?: never;
			responses: {
				/** @description OK */
				200: {
					headers: {
						[name: string]: unknown;
					};
					content: {
						"text/plain": components["schemas"]["BaseResponse"];
						"application/json": components["schemas"]["BaseResponse"];
						"text/json": components["schemas"]["BaseResponse"];
					};
				};
			};
		};
		delete?: never;
		options?: never;
		head?: never;
		patch?: never;
		trace?: never;
	};
	"/api/auth/me": {
		parameters: {
			query?: never;
			header?: never;
			path?: never;
			cookie?: never;
		};
		get: {
			parameters: {
				query?: never;
				header?: never;
				path?: never;
				cookie?: never;
			};
			requestBody?: never;
			responses: {
				/** @description OK */
				200: {
					headers: {
						[name: string]: unknown;
					};
					content: {
						"text/plain": components["schemas"]["UserItemDetailsBaseResponse"];
						"application/json": components["schemas"]["UserItemDetailsBaseResponse"];
						"text/json": components["schemas"]["UserItemDetailsBaseResponse"];
					};
				};
			};
		};
		put?: never;
		post?: never;
		delete?: never;
		options?: never;
		head?: never;
		patch?: never;
		trace?: never;
	};
	"/api/feed": {
		parameters: {
			query?: never;
			header?: never;
			path?: never;
			cookie?: never;
		};
		get: {
			parameters: {
				query?: never;
				header?: never;
				path?: never;
				cookie?: never;
			};
			requestBody?: never;
			responses: {
				/** @description OK */
				200: {
					headers: {
						[name: string]: unknown;
					};
					content: {
						"text/plain": components["schemas"]["PostItemPaginated"];
						"application/json": components["schemas"]["PostItemPaginated"];
						"text/json": components["schemas"]["PostItemPaginated"];
					};
				};
			};
		};
		put?: never;
		post?: never;
		delete?: never;
		options?: never;
		head?: never;
		patch?: never;
		trace?: never;
	};
	"/api/posts": {
		parameters: {
			query?: never;
			header?: never;
			path?: never;
			cookie?: never;
		};
		get?: never;
		put?: never;
		post: {
			parameters: {
				query?: never;
				header?: never;
				path?: never;
				cookie?: never;
			};
			requestBody?: {
				content: {
					"application/json": components["schemas"]["CreatePostCommand"];
					"text/json": components["schemas"]["CreatePostCommand"];
					"application/*+json": components["schemas"]["CreatePostCommand"];
				};
			};
			responses: {
				/** @description OK */
				200: {
					headers: {
						[name: string]: unknown;
					};
					content?: never;
				};
			};
		};
		delete?: never;
		options?: never;
		head?: never;
		patch?: never;
		trace?: never;
	};
}
export type webhooks = Record<string, never>;
export interface components {
	schemas: {
		BaseResponse: {
			readonly hasNotifications?: boolean;
			notifications?: {
				[key: string]: string[];
			} | null;
			httpStatusCode?: components["schemas"]["HttpStatusCode"];
		};
		CreatePostCommand: {
			content?: string | null;
			access?: components["schemas"]["PostAccess"];
			/** Format: date-time */
			scheduledAt?: string | null;
		};
		GuidBaseResponse: {
			readonly hasNotifications?: boolean;
			notifications?: {
				[key: string]: string[];
			} | null;
			httpStatusCode?: components["schemas"]["HttpStatusCode"];
			/** Format: uuid */
			data?: string;
		};
		/** @enum {string} */
		HttpStatusCode: HttpStatusCode;
		LoginUserCommand: {
			emailOrUsername?: string | null;
			password?: string | null;
		};
		/** @enum {string} */
		PostAccess: PostAccess;
		PostItem: {
			/** Format: uuid */
			id: string;
			content: string | null;
			/** Format: uuid */
			authorId: string;
			access: components["schemas"]["PostAccess"];
			/** Format: int32 */
			likesCount: number;
			/** Format: int32 */
			commentsCount: number;
			/** Format: date-time */
			createdAt: string;
			/** Format: date-time */
			lastUpdatedAt: string | null;
			author: components["schemas"]["UserAuthorItem"];
		};
		PostItemPaginated: {
			items?: components["schemas"]["PostItem"][] | null;
			/** Format: int32 */
			pageIndex?: number;
			/** Format: int32 */
			pageSize?: number;
			/** Format: int64 */
			totalCount?: number;
			/** Format: int32 */
			readonly totalPages?: number;
			readonly hasPreviousPage?: boolean;
			readonly hasNextPage?: boolean;
		};
		RegisterUserCommand: {
			name?: string | null;
			username?: string | null;
			email?: string | null;
			password?: string | null;
			bio?: string | null;
			/** Format: date */
			birthday?: string;
		};
		UserAuthorItem: {
			/** Format: uuid */
			id?: string;
			name: string | null;
			username: string | null;
		};
		UserItemDetails: {
			/** Format: uuid */
			id: string;
			name: string | null;
			username: string | null;
			bio: string | null;
			/** Format: date */
			birthday: string;
			/** Format: date-time */
			createdAt: string;
			/** Format: int32 */
			followersCount: number;
			/** Format: int32 */
			followingCount: number;
			/** Format: int32 */
			postsCount: number;
		};
		UserItemDetailsBaseResponse: {
			readonly hasNotifications?: boolean;
			notifications?: {
				[key: string]: string[];
			} | null;
			httpStatusCode?: components["schemas"]["HttpStatusCode"];
			data?: components["schemas"]["UserItemDetails"];
		};
	};
	responses: never;
	parameters: never;
	requestBodies: never;
	headers: never;
	pathItems: never;
}
export type $defs = Record<string, never>;
export enum HttpStatusCode {
	Continue = "Continue",
	SwitchingProtocols = "SwitchingProtocols",
	Processing = "Processing",
	EarlyHints = "EarlyHints",
	OK = "OK",
	Created = "Created",
	Accepted = "Accepted",
	NonAuthoritativeInformation = "NonAuthoritativeInformation",
	NoContent = "NoContent",
	ResetContent = "ResetContent",
	PartialContent = "PartialContent",
	MultiStatus = "MultiStatus",
	AlreadyReported = "AlreadyReported",
	IMUsed = "IMUsed",
	MultipleChoices = "MultipleChoices",
	MovedPermanently = "MovedPermanently",
	Found = "Found",
	SeeOther = "SeeOther",
	NotModified = "NotModified",
	UseProxy = "UseProxy",
	Unused = "Unused",
	TemporaryRedirect = "TemporaryRedirect",
	PermanentRedirect = "PermanentRedirect",
	BadRequest = "BadRequest",
	Unauthorized = "Unauthorized",
	PaymentRequired = "PaymentRequired",
	Forbidden = "Forbidden",
	NotFound = "NotFound",
	MethodNotAllowed = "MethodNotAllowed",
	NotAcceptable = "NotAcceptable",
	ProxyAuthenticationRequired = "ProxyAuthenticationRequired",
	RequestTimeout = "RequestTimeout",
	Conflict = "Conflict",
	Gone = "Gone",
	LengthRequired = "LengthRequired",
	PreconditionFailed = "PreconditionFailed",
	RequestEntityTooLarge = "RequestEntityTooLarge",
	RequestUriTooLong = "RequestUriTooLong",
	UnsupportedMediaType = "UnsupportedMediaType",
	RequestedRangeNotSatisfiable = "RequestedRangeNotSatisfiable",
	ExpectationFailed = "ExpectationFailed",
	MisdirectedRequest = "MisdirectedRequest",
	UnprocessableEntity = "UnprocessableEntity",
	Locked = "Locked",
	FailedDependency = "FailedDependency",
	UpgradeRequired = "UpgradeRequired",
	PreconditionRequired = "PreconditionRequired",
	TooManyRequests = "TooManyRequests",
	RequestHeaderFieldsTooLarge = "RequestHeaderFieldsTooLarge",
	UnavailableForLegalReasons = "UnavailableForLegalReasons",
	InternalServerError = "InternalServerError",
	NotImplemented = "NotImplemented",
	BadGateway = "BadGateway",
	ServiceUnavailable = "ServiceUnavailable",
	GatewayTimeout = "GatewayTimeout",
	HttpVersionNotSupported = "HttpVersionNotSupported",
	VariantAlsoNegotiates = "VariantAlsoNegotiates",
	InsufficientStorage = "InsufficientStorage",
	LoopDetected = "LoopDetected",
	NotExtended = "NotExtended",
	NetworkAuthenticationRequired = "NetworkAuthenticationRequired",
}
export enum PostAccess {
	Public = "Public",
	Followers = "Followers",
	Private = "Private",
}
export type operations = Record<string, never>;