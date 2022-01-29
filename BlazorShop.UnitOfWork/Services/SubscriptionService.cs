namespace BlazorShop.UnitOfWork.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<SubscriptionService> _logger;

        public SubscriptionService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<SubscriptionService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public List<SubscriptionResponse> GetAll()
        {
            try
            {
                var result = _unitOfWork.SubscriptionRepository.GetAll();
                var subscriptions = _mapper.Map<List<SubscriptionResponse>>(result);
                return subscriptions;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error while getting the subscriptions.");
                return new List<SubscriptionResponse>
                {
                    new SubscriptionResponse
                    {
                        Error = $"There was an error while getting the subscriptions. {ex.Message}. {ex.InnerException?.Message}"
                    }
                };
            }
        }

        public SubscriptionResponse Get(int id)
        {
            try
            {
                var result = _unitOfWork.SubscriptionRepository.Get(id);
                var subscription = _mapper.Map<SubscriptionResponse>(result);
                return subscription;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error while getting the subscription by id.");
                return new SubscriptionResponse
                {
                    Error = $"There was an error while getting the subscription by id. {ex.Message}. {ex.InnerException?.Message}"
                };
            }
        }

        public RequestResponse AddSubscription(SubscriptionResponse subscription)
        {
            try
            {
                var entity = _unitOfWork.SubscriptionRepository.Get(subscription.Id);
                if (entity != null) throw new ArgumentNullException();

                entity = new Subscription
                {
                    Name = subscription.Name,
		            Price = subscription.Price,
		            Currency = subscription.Currency,
		            CurrencySymbol = subscription.CurrencySymbol,
		            ChargeType = subscription.ChargeType,
		            Options = subscription.Options,
                };

                _unitOfWork.SubscriptionRepository.Add(entity);
                _unitOfWork.Commit();
                return RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error creating the subscription");
                return RequestResponse.Failure($"There was an error creating the subscription. {ex.Message}. {ex.InnerException?.Message}");
            }
        }

        public RequestResponse UpdateSubscription(SubscriptionResponse subscription)
        {
            try
            {
                var entity = _unitOfWork.SubscriptionRepository.Get(subscription.Id);
                if (entity == null) throw new ArgumentNullException();

                entity.Name = subscription.Name;
                entity.Price = subscription.Price;
                entity.Currency = subscription.Currency;
                entity.CurrencySymbol = subscription.CurrencySymbol;
                entity.ChargeType = subscription.ChargeType;
                entity.Options = subscription.Options;

                _unitOfWork.SubscriptionRepository.Update(entity);
                _unitOfWork.Commit();
                return RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error updating the subscription");
                return RequestResponse.Failure($"There was an error updating the subscription. {ex.Message}. {ex.InnerException?.Message}");
            }
        }

        public RequestResponse DeleteSubscription(int id)
        {
            try
            {
                var entity = _unitOfWork.SubscriptionRepository.Get(id);
                if (entity == null) throw new ArgumentNullException();

                _unitOfWork.SubscriptionRepository.Delete(entity);
                _unitOfWork.Commit();
                return RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error deleting the subscription");
                return RequestResponse.Failure($"There was an error deleting the subscription. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}
